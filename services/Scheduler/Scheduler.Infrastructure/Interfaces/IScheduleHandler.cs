using Scheduler.Domain.Interfaces;
using Scheduler.Infrastructure.Requests;
using Scheduler.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Scheduler.Infrastructure.Interfaces
{
    public interface IScheduleHandler
    {
        Task Handle(SchedulesRequest message, IOutputPort<SchedulesResponse> outputPort);
    }
}
