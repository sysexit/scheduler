using Timesheets.Domain.Bus;
using Timesheets.Domain.CommandHandlers;
using Timesheets.Domain.Interfaces;
using Timesheets.Domain.Notifications;
using Timesheets.Infrastructure.Interfaces;
using Timesheets.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;
using Timesheets.Infrastructure.Responses;
using Microsoft.Extensions.Logging;

namespace Timesheets.Infrastructure.TimesheetHandlers
{
    public class UpdateTimesheetHandler : CommandHandler, IUpdateTimesheetHandler
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public UpdateTimesheetHandler(ITimesheetRepository timesheetRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _timesheetRepository = timesheetRepository;
            _logger = loggerFactory.CreateLogger<UpdateTimesheetHandler>();
            Bus = bus;
        }

        public async Task Handle(TimesheetsRequest message, IOutputPort<TimesheetResponse> outputPort)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid update timesheet request.");
                NotifyValidationErrors(message);
                return;
            }

            var timesheet = new Domain.Entities.Timesheet(message.TimesheetId, message.UserId, message.Start, message.End);
            _timesheetRepository.Update(timesheet);

            if (Commit())
            {
                _logger.LogInformation("Updated timesheet {0} for user {0}.", message.TimesheetId, message.UserId);
                outputPort.Handle(new TimesheetResponse(timesheet));
                return;
            }

            _logger.LogInformation("Error handling update timesheet request.");
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Updating timesheet failed"));
        }
    }
}
