using Scheduler.Domain.Bus;
using Scheduler.Domain.CommandHandlers;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Notifications;
using Scheduler.Infrastructure.Interfaces;
using Scheduler.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;
using Scheduler.Infrastructure.Responses;
using Microsoft.Extensions.Logging;

namespace Scheduler.Infrastructure.TimesheetHandlers
{
    public class UpdateScheduleHandler : CommandHandler, IUpdateScheduleHandler
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public UpdateScheduleHandler(IScheduleRepository scheduleRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _scheduleRepository = scheduleRepository;
            _logger = loggerFactory.CreateLogger<UpdateScheduleHandler>();
            Bus = bus;
        }

        public async Task Handle(SchedulesRequest message, IOutputPort<ScheduleResponse> outputPort)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid update schedule request.");
                NotifyValidationErrors(message);
                return;
            }

            var schedule = new Domain.Entities.Schedule(message.Id, message.UserId, message.Start, message.End, message.Position);
            _scheduleRepository.Update(schedule);

            if (Commit())
            {
                _logger.LogInformation("Updated schedule {0}.", schedule.Id);
                outputPort.Handle(new ScheduleResponse(schedule));
                return;
            }

            _logger.LogInformation("Error handling update schedule request.");
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Updating schedule failed"));
        }
    }
}
