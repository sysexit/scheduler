using Scheduler.Domain.Bus;
using Scheduler.Domain.CommandHandlers;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Notifications;
using Scheduler.Infrastructure.Interfaces;
using Scheduler.Infrastructure.Requests;
using Scheduler.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;
using Scheduler.Infrastructure.Helpers;
using Scheduler.Domain.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Scheduler.Infrastructure.TimesheetHandlers
{
    public class ScheduleHandler : CommandHandler, IScheduleHandler
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public ScheduleHandler(IScheduleRepository scheduleRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _scheduleRepository = scheduleRepository;
            _logger = loggerFactory.CreateLogger<ScheduleHandler>();
            Bus = bus;
        }

        public async Task Handle(SchedulesRequest message, IOutputPort<SchedulesResponse> outputPort)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            List<Schedule> schedules = new List<Schedule>();

            // Only find published schedules if user is not an admin
            if(message.GroupId != int.Parse(Constants.Strings.JwtClaims.Admin))
            {
                schedules.AddRange(await _scheduleRepository.FindPublishedSchedulesAsync(message.Start, message.End));
            } else // Show unpublished for admin users
            {
                schedules.AddRange(await _scheduleRepository.FindByStartAndEndAsync(message.Start, message.End));
            }

            _logger.LogInformation("Loaded schedules between {0} and {1}.", message.Start, message.End);
            outputPort.Handle(new SchedulesResponse(schedules));
        }
    }
}
