using Auth.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Interfaces
{
    public interface IOnboardHandler
    {
        Task Handle(OnboardRequest message);
    }
}
