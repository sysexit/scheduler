using Users.Domain.Interfaces;
using Users.Infrastructure.Requests;
using Users.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Users.Infrastructure.Interfaces
{
    public interface IUserHandler
    {
        Task Handle(UserListRequest message, IOutputPort<UsersResponse> outputPort);
    }
}
