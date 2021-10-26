using Scheduler.Domain.Entities;
using Scheduler.Domain.Interfaces;
using Scheduler.Infrastructure.Context;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Scheduler.Infrastructure.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private readonly ScheduleContext _context;

        public ScheduleRepository(ScheduleContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public Task<Schedule> FindByIdAsync(int id)
        {
            return _context.Schedule.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Schedule>> FindByStartAndEndAsync(Instant start, Instant end)
        {
            return _context.Schedule
                .Where(x => x.Start >= start && x.End <= end)
                .Select(x => new Schedule(x.Id, x.UserId, x.Start, x.End, x.Position, x.Published))
                .ToListAsync();
        }

        public Task<List<Schedule>> FindPublishedSchedulesAsync(Instant start, Instant end)
        {
            return _context.Schedule
                .Where(x => x.Start >= start && x.End <= end && x.Published)
                .Select(x => new Schedule(x.Id, x.UserId, x.Start, x.End, x.Position, x.Published))
                .ToListAsync();
        }
    }
}
