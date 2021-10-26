using Users.Domain.Commands;
using Users.Domain.Events;
using System.Threading.Tasks;

namespace Users.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
