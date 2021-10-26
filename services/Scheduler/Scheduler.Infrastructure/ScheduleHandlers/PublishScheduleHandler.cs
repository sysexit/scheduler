using Scheduler.Domain.Bus;
using Scheduler.Domain.CommandHandlers;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Notifications;
using Scheduler.Infrastructure.Interfaces;
using Scheduler.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;
using Scheduler.Infrastructure.Requests;
using Scheduler.Domain.Entities;
using System;
using Microsoft.Extensions.Logging;

namespace Scheduler.Infrastructure.TimesheetHandlers
{
    public class PublishScheduleHandler : CommandHandler, IPublishScheduleHandler
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public PublishScheduleHandler(IScheduleRepository scheduleRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _scheduleRepository = scheduleRepository;
            _logger = loggerFactory.CreateLogger<PublishScheduleHandler>();
            Bus = bus;
        }

        public async Task Handle(SchedulesRequest message)
        {
            var schedules = await _scheduleRepository.FindByStartAndEndAsync(message.Start, message.End);

            foreach (Schedule s in schedules)
            {
                if (s.Published) continue;

                var a = new Schedule(s.Id, s.UserId, s.Start, s.End, s.Position);
                a.Published = true;
                _scheduleRepository.Update(a);
            }

            _logger.LogInformation("Published schedules between {0} and {1}.", message.Start, message.End);
            Commit();
        }
    }
}
