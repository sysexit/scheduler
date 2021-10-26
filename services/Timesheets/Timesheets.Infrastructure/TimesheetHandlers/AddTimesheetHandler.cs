using Timesheets.Domain.Bus;
using Timesheets.Domain.CommandHandlers;
using Timesheets.Domain.Interfaces;
using Timesheets.Domain.Notifications;
using Timesheets.Infrastructure.Interfaces;
using Timesheets.Infrastructure.Requests;
using Timesheets.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Timesheets.Infrastructure.TimesheetHandlers
{
    public class AddTimesheetHandler : CommandHandler, IAddTimesheetHandler
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public AddTimesheetHandler(ITimesheetRepository timesheetRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _timesheetRepository = timesheetRepository;
            _logger = loggerFactory.CreateLogger<AddTimesheetHandler>();
            Bus = bus;
        }

        public async Task Handle(TimesheetsRequest message, IOutputPort<TimesheetResponse> outputPort)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid add timesheet request.");
                NotifyValidationErrors(message);
                return;
            }

            var timesheet = new Domain.Entities.Timesheet(message.UserId, message.Start, message.End);
            await _timesheetRepository.AddAsync(timesheet);

            if (Commit())
            {
                _logger.LogInformation("Added default timesheet for user {0}.", message.UserId);
                outputPort.Handle(new TimesheetResponse(timesheet));
                return;
            }

            _logger.LogInformation("Error handling add timesheet request.");
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Adding timesheet failed"));
        }
    }
}
