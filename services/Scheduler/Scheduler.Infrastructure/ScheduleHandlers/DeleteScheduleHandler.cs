using Scheduler.Domain.Bus;
using Scheduler.Domain.CommandHandlers;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Notifications;
using Scheduler.Infrastructure.Interfaces;
using Scheduler.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Scheduler.Infrastructure.TimesheetHandlers
{
    public class DeleteScheduleHandler : CommandHandler, IDeleteScheduleHandler
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public DeleteScheduleHandler(IScheduleRepository scheduleRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _scheduleRepository = scheduleRepository;
            _logger = loggerFactory.CreateLogger<DeleteScheduleHandler>();
            Bus = bus;
        }

        public async Task Handle(SchedulesRequest message)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid delete schedule request.");
                NotifyValidationErrors(message);
                return;
            }

            var schedule = _scheduleRepository.FindByIdAsync(message.Id);
            if (schedule.Result != null)
            {
                _scheduleRepository.Remove(schedule.Result);

                if (Commit())
                {
                    _logger.LogInformation("Deleted schedule {0}.", schedule.Id);
                    return;
                }
            }

            _logger.LogInformation("Error handling delete schedule request.");
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Removing schedule failed"));
        }
    }
}
