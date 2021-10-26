using Users.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Users.Infrastructure.Interfaces
{
    public interface IUpdateUserStatusHandler
    {
        Task Handle(UserStatusRequest message);
    }
}
