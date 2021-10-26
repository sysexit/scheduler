using Timesheets.Domain.Bus;
using Timesheets.Domain.CommandHandlers;
using Timesheets.Domain.Interfaces;
using Timesheets.Domain.Notifications;
using Timesheets.Infrastructure.Interfaces;
using Timesheets.Infrastructure.Requests;
using Timesheets.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;
using Timesheets.Domain.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Timesheets.Infrastructure.TimesheetHandlers
{
    public class AddDefaultTimesheetHandler : CommandHandler, IAddDefaultTimesheetHandler
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public AddDefaultTimesheetHandler(ITimesheetRepository timesheetRepository,
            IScheduleRepository scheduleRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _timesheetRepository = timesheetRepository;
            _scheduleRepository = scheduleRepository;
            _logger = loggerFactory.CreateLogger<AddDefaultTimesheetHandler>();
            Bus = bus;
        }

        public async Task Handle(TimesheetsRequest message, IOutputPort<TimesheetsResponse> outputPort)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid add default timesheets request.");
                NotifyValidationErrors(message);
                return;
            }

            var schedules = await _scheduleRepository.FindByStartEndIdAsync(message.UserId, message.Start, message.End);
            if (schedules.Count == 0)
            {
                _logger.LogInformation("Invalid add default timesheets request.");
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "No schedules for given period"));
                return;
            }

            var existingTimesheets = await _timesheetRepository.FindByUserIdAsync(message.UserId, message.Start, message.End);
            if (existingTimesheets.Count > 0)
            {
                _logger.LogInformation("Invalid add default timesheets request.");
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Cannot add default timesheets if there are exisiting timesheets in given period."));
                return;
            }

            List<Timesheet> timesheets = new List<Timesheet>();

            foreach (Schedule s in schedules)
            {
                var timesheet = new Timesheet(s.UserId, s.Start, s.End);
                await _timesheetRepository.AddAsync(timesheet);
                timesheets.Add(timesheet);
            }

            if (Commit())
            {
                _logger.LogInformation("Added default timesheets for user {0}.", message.UserId);
                outputPort.Handle(new TimesheetsResponse(timesheets));
                return;
            }

            _logger.LogInformation("Error handling add default timesheets request.");
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Adding timesheets failed"));
        }
    }
}
