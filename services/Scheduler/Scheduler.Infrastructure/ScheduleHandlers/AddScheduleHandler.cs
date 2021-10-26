using Scheduler.Domain.Bus;
using Scheduler.Domain.CommandHandlers;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Notifications;
using Scheduler.Infrastructure.Interfaces;
using Scheduler.Infrastructure.Requests;
using Scheduler.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Scheduler.Infrastructure.TimesheetHandlers
{
    public class AddScheduleHandler : CommandHandler, IAddScheduleHandler
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public AddScheduleHandler(IScheduleRepository timesheetRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _scheduleRepository = timesheetRepository;
            _logger = loggerFactory.CreateLogger<AddScheduleHandler>();
            Bus = bus;
        }

        public async Task Handle(SchedulesRequest message, IOutputPort<ScheduleResponse> outputPort)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid add schedule request.");
                NotifyValidationErrors(message);
                return;
            }

            var schedule = new Domain.Entities.Schedule(message.UserId, message.Start, message.End, message.Position);
            await _scheduleRepository.AddAsync(schedule);

            if (Commit())
            {
                _logger.LogInformation("Added new schedule {0}.", schedule.Id);
                outputPort.Handle(new ScheduleResponse(schedule));
                return;
            }

            _logger.LogInformation("Error handling add schedule request.");
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Adding schedule failed"));
        }
    }
}
