using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Domain.Entities;

namespace Timesheets.Domain.Interfaces
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<List<Schedule>> FindByStartAndEndAsync(DateTime start, DateTime end);
        Task<Schedule> FindByIdAsync(int id);
        Task<List<Schedule>> FindByStartEndIdAsync(int id, DateTime start, DateTime end);
    }
}
