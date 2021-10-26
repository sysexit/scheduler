using Scheduler.Infrastructure.Dto;
using System.Collections.Generic;

namespace Scheduler.Infrastructure.Responses
{
    public class SchedulesResponse
    {
        public List<Schedule> Schedules { get; }

        public SchedulesResponse(List<Schedule> schedules)
        {
            Schedules = schedules;
        }

        public SchedulesResponse(List<Domain.Entities.Schedule> schedules)
        {
            List<Schedule> schedulesList = new List<Schedule>();
            foreach (Domain.Entities.Schedule s in schedules) {
                var times = new Schedule(s.Id, s.UserId, s.Start, s.End, s.Position, s.Published);
                schedulesList.Add(times);
            }
            Schedules = schedulesList;
        }

        public SchedulesResponse(Domain.Entities.Schedule schedule)
        {
            List<Schedule> schedulesList = new List<Schedule>();
            var sheet = new Schedule(schedule.Id, schedule.UserId, schedule.Start, schedule.End, schedule.Position, schedule.Published);
            schedulesList.Add(sheet);
            Schedules = schedulesList;
        }
    }
}
