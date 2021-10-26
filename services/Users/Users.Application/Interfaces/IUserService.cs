using Users.Application.ViewModels;
using Users.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Users.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<UsersResponse> GetUsers(GetUsersViewModel model);
        Task<UserResponse> GetUser(int id);
        Task UpdateUser(UpdateUserViewModel model);
        Task UpdateUserStatus(UpdateUserStatusViewModel model);
    }
}
