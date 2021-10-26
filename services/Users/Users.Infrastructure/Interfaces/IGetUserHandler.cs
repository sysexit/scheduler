using Users.Domain.Interfaces;
using Users.Infrastructure.Requests;
using Users.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Users.Infrastructure.Interfaces
{
    public interface IGetUserHandler
    {
        Task Handle(UsersRequest message, IOutputPort<UserResponse> outputPort);
    }
}
