using Scheduler.Application.ViewModels;
using Scheduler.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Scheduler.Application.Interfaces
{
    public interface IScheduleService : IDisposable
    {
        Task<SchedulesResponse> GetSchedule(int groupId, GetScheduleViewModel model);
        Task PublishSchedule(PublishScheduleViewModel model);
        Task<ScheduleResponse> AddSchedule(AddScheduleViewModel model);
        Task<ScheduleResponse> UpdateSchedule(UpdateScheduleViewModel model);
        Task DeleteTimesheet(DeleteScheduleViewModel model);
    }
}
