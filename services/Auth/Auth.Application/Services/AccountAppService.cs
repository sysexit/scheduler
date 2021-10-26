using Auth.Application.Interfaces;
using Auth.Application.ViewModels;
using Auth.Infrastructure.Interfaces;
using Auth.Infrastructure.Presenters;
using Auth.Infrastructure.Requests;
using Auth.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Auth.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly ILoginHandler _loginHandler;
        private readonly IForgotPasswordHandler _forgotPasswordHandler;
        private readonly IResetPasswordHandler _resetPasswordHandler;
        private readonly IOnboardHandler _onboardHandler;
        private readonly IUpdatePasswordHandler _updatePasswordHandler;
        private readonly LoginPresenter _loginPresenter;

        public AccountAppService(
            ILoginHandler loginHandler,
            IForgotPasswordHandler forgotPasswordHandler,
            IResetPasswordHandler resetPasswordHandler,
            IOnboardHandler onboardHandler,
            IUpdatePasswordHandler updatePasswordHandler)
        {
            _loginHandler = loginHandler;
            _forgotPasswordHandler = forgotPasswordHandler;
            _resetPasswordHandler = resetPasswordHandler;
            _onboardHandler = onboardHandler;
            _updatePasswordHandler = updatePasswordHandler;
            _loginPresenter = new LoginPresenter();
        }

        public async Task<LoginResponse> Login(LoginViewModel request)
        {
            await _loginHandler.Handle(new LoginRequest(request.Email, request.Password, request.RemoteIPAddress), _loginPresenter);
            return _loginPresenter.data;
        }

        public async Task ForgotPassword(ForgotPasswordViewModel request)
        {
            await _forgotPasswordHandler.Handle(new ForgotPasswordRequest(request.Email, request.RemoteIpAddress));
        }

        public async Task ResetPassword(ResetPasswordViewModel request)
        {
            await _resetPasswordHandler.Handle(new ResetPasswordRequest(request.Email, request.Password, request.PasswordConfirm, request.Token, request.RemoteIpAddress));
        }

        public async Task Onboard(OnboardViewModel request)
        {
            await _onboardHandler.Handle(new OnboardRequest(request.Email, request.First, request.Last, request.Positions, request.RemoteIpAddress));
        }

        public async Task UpdatePassword(UpdatePasswordViewModel request, int userId)
        {
            await _updatePasswordHandler.Handle(new UpdatePasswordRequest(userId, request.CurrentPassword, request.NewPassword, request.NewPasswordConfirm));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
