using Scheduler.Infrastructure.Requests;
using System.Threading.Tasks;
using Scheduler.Infrastructure.Responses;
using Scheduler.Domain.Interfaces;

namespace Scheduler.Infrastructure.Interfaces
{
    public interface IUpdateScheduleHandler
    {
        Task Handle(SchedulesRequest message, IOutputPort<ScheduleResponse> outputPort);
    }
}
