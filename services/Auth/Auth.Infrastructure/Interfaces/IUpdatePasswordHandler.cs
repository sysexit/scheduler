using Auth.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Interfaces
{
    public interface IUpdatePasswordHandler
    {
        Task Handle(UpdatePasswordRequest message);
    }
}
