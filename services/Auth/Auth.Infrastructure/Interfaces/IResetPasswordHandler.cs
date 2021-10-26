using Auth.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Interfaces
{
    public interface IResetPasswordHandler
    {
        Task Handle(ResetPasswordRequest message);
    }
}
