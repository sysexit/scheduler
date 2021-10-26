using Users.Application.Interfaces;
using Users.Application.ViewModels;
using Users.Infrastructure.Interfaces;
using Users.Infrastructure.Presenters;
using Users.Infrastructure.Requests;
using Users.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserHandler _userHandler;
        private readonly IGetUserHandler _getUserHandler;
        private readonly IUpdateUserHandler _updateUserHandler;
        private readonly IUpdateUserStatusHandler _updateUserStatusHandler;
        private readonly UsersPresenter _usersPresenter;
        private readonly UserPresenter _userPresenter;

        public UserService(IUserHandler userHandler, 
            IGetUserHandler getUserHandler,
            IUpdateUserHandler updateScheduleHandler, 
            IUpdateUserStatusHandler updateUserStatusHandler)
        {
            _userHandler = userHandler;
            _getUserHandler = getUserHandler;
            _updateUserHandler = updateScheduleHandler;
            _updateUserStatusHandler = updateUserStatusHandler;
            _usersPresenter = new UsersPresenter();
            _userPresenter = new UserPresenter();
        }

        public async Task<UsersResponse> GetUsers(GetUsersViewModel model)
        {
            await _userHandler.Handle(new UserListRequest(model.Type), _usersPresenter);
            return _usersPresenter.data;
        }

        public async Task<UserResponse> GetUser(int id)
        {
            await _getUserHandler.Handle(new UsersRequest(id), _userPresenter);
            return _userPresenter.data;
        }

        public async Task UpdateUser(UpdateUserViewModel model)
        {
            await _updateUserHandler.Handle(new UsersRequest(model.UserId, model.Email, model.First, model.Last, model.Positions, model.Display, model.Enabled), _userPresenter);
        }

        public async Task UpdateUserStatus(UpdateUserStatusViewModel model)
        {
            await _updateUserStatusHandler.Handle(new UserStatusRequest(model.Email, model.Enabled));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
