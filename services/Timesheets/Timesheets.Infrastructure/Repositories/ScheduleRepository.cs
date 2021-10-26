using Timesheets.Domain.Entities;
using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Context;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace Timesheets.Infrastructure.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private readonly TimesheetsContext _context;

        public ScheduleRepository(TimesheetsContext context) : base(context)
        {
            _context = context;
        }

        public Task<Schedule> FindByIdAsync(int id)
        {
            return _context.Schedule.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Schedule>> FindByStartAndEndAsync(DateTime start, DateTime end)
        {
            return _context.Schedule
                .Where(x => x.Start >= start && x.End <= end)
                .Select(x => new Schedule(x.Id, x.UserId, x.Start, x.End, x.Position, x.Published))
                .ToListAsync();
        }

        public Task<List<Schedule>> FindByStartEndIdAsync(int id, DateTime start, DateTime end)
        {
            return _context.Schedule
                .Where(x => x.UserId == id && x.Start >= start && x.End <= end)
                .Select(x => new Schedule(x.Id, x.UserId, x.Start, x.End, x.Position, x.Published))
                .ToListAsync();
        }
    }
}
