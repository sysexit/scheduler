using Timesheets.Domain.Commands;
using Timesheets.Domain.Events;
using System.Threading.Tasks;

namespace Timesheets.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
