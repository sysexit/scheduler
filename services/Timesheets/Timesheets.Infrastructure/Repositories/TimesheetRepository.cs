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
    public class TimesheetRepository : Repository<Timesheet>, ITimesheetRepository
    {
        private readonly TimesheetsContext _context;

        public TimesheetRepository(TimesheetsContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public Task<List<Timesheet>> FindByUserIdAsync(int userId, DateTime start, DateTime end)
        {
            return _context.Timesheets
                .Where(x => x.UserId == userId && x.Start >= start && x.End <= end)
                .Select(x => new Timesheet(x.Id, x.UserId, x.Start, x.End))
                .ToListAsync();
        }

        public Task<Timesheet> FindByUserTimesheetIdAsync(int userId, int timesheetId)
        {
            return _context.Timesheets.FirstOrDefaultAsync(ts => ts.Id == timesheetId && ts.UserId == userId);
        }
    }
}
