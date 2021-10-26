using Auth.Application.ViewModels;
using Auth.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Interfaces
{
    public interface IAccountAppService : IDisposable
    {
        Task<LoginResponse> Login(LoginViewModel request);
        Task ForgotPassword(ForgotPasswordViewModel request);
        Task ResetPassword(ResetPasswordViewModel request);
        Task Onboard(OnboardViewModel request);
        Task UpdatePassword(UpdatePasswordViewModel request, int userId);
    }
}
