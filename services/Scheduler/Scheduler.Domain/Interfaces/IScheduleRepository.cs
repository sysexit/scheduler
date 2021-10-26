using System.Collections.Generic;
using System.Threading.Tasks;
using NodaTime;
using Scheduler.Domain.Entities;

namespace Scheduler.Domain.Interfaces
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<List<Schedule>> FindByStartAndEndAsync(Instant start, Instant end);
        Task<List<Schedule>> FindPublishedSchedulesAsync(Instant start, Instant end);
        Task<Schedule> FindByIdAsync(int id);
    }
}
