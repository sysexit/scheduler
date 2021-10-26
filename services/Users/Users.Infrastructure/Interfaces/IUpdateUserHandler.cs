using Users.Infrastructure.Requests;
using System.Threading.Tasks;
using Users.Infrastructure.Responses;
using Users.Domain.Interfaces;

namespace Users.Infrastructure.Interfaces
{
    public interface IUpdateUserHandler
    {
        Task Handle(UsersRequest message, IOutputPort<UserResponse> outputPort);
    }
}
