using Templates.Domain.Commands;
using Templates.Domain.Events;
using System.Threading.Tasks;

namespace Templates.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
