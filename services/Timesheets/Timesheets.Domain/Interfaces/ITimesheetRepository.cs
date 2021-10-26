using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces
{
    public interface ITimesheetRepository : IRepository<Timesheet>
    {
        Task<List<Timesheet>> FindByUserIdAsync(int userId, DateTime start, DateTime end);
        Task<Timesheet> FindByUserTimesheetIdAsync(int userId, int timesheetId);
    }
}
