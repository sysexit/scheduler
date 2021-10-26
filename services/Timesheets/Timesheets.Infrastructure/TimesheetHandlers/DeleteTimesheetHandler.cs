using Timesheets.Domain.Bus;
using Timesheets.Domain.CommandHandlers;
using Timesheets.Domain.Interfaces;
using Timesheets.Domain.Notifications;
using Timesheets.Infrastructure.Interfaces;
using Timesheets.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Timesheets.Infrastructure.TimesheetHandlers
{
    public class DeleteTimesheetHandler : CommandHandler, IDeleteTimesheetHandler
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public DeleteTimesheetHandler(ITimesheetRepository timesheetRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _timesheetRepository = timesheetRepository;
                        _logger = loggerFactory.CreateLogger<DeleteTimesheetHandler>();
            Bus = bus;
        }

        public async Task Handle(TimesheetsRequest message)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid delete timesheet request.");
                NotifyValidationErrors(message);
                return;
            }

            var timesheet = _timesheetRepository.FindByUserTimesheetIdAsync(message.UserId, message.TimesheetId);
            if (timesheet.Result != null)
            {
                _timesheetRepository.Remove(timesheet.Result);

                if (Commit())
                {
                    _logger.LogInformation("Deleted timesheet {0} for user {1}.", message.TimesheetId, message.UserId);
                    return;
                }
            }

            _logger.LogInformation("Error handling delete timesheet request.");
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Removing timesheet failed"));
        }
    }
}
