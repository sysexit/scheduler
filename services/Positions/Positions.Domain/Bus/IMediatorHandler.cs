using Positions.Domain.Commands;
using Positions.Domain.Events;
using System.Threading.Tasks;

namespace Positions.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
