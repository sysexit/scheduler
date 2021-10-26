using Scheduler.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Scheduler.Infrastructure.Interfaces
{
    public interface IPublishScheduleHandler
    {
        Task Handle(SchedulesRequest message);
    }
}
