using Scheduler.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Scheduler.Infrastructure.Interfaces
{
    public interface IDeleteScheduleHandler
    {
        Task Handle(SchedulesRequest message);
    }
}
