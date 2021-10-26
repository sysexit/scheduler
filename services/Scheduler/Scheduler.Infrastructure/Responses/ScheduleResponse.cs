using Scheduler.Infrastructure.Dto;

namespace Scheduler.Infrastructure.Responses
{
    public class ScheduleResponse
    {
        public Schedule Schedule { get; }

        public ScheduleResponse(Domain.Entities.Schedule schedule)
        {
            Schedule = new Schedule(schedule.Id, schedule.UserId, schedule.Start, schedule.End, schedule.Position, schedule.Published);
        }
    }
}
