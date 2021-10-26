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
    public class TimesheetsHandler : CommandHandler, ITimesheetsHandler
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public TimesheetsHandler(ITimesheetRepository timesheetRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _timesheetRepository = timesheetRepository;
            _logger = loggerFactory.CreateLogger<TimesheetsHandler>();
            Bus = bus;
        }

        public async Task Handle(TimesheetsRequest message, IOutputPort<TimesheetsResponse> outputPort)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid get timesheets request.");
                NotifyValidationErrors(message);
                return;
            }

            var timesheets = await _timesheetRepository.FindByUserIdAsync(message.UserId, message.Start, message.End);
            _logger.LogInformation("Loaded timesheets for user {0}.", message.UserId);
            outputPort.Handle(new TimesheetsResponse(timesheets));
        }
    }
}
