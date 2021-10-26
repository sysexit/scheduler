using Auth.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Interfaces
{
    public interface IForgotPasswordHandler
    {
        Task Handle(ForgotPasswordRequest message);
    }
}
