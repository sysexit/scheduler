using Scheduler.Domain.Commands;
using Scheduler.Domain.Events;
using System.Threading.Tasks;

namespace Scheduler.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
