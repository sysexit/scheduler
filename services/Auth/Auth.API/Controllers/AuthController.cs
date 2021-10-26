using Auth.Application.Interfaces;
using Auth.Application.ViewModels;
using Auth.Domain.Bus;
using Auth.Domain.Notifications;
using Auth.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ApiController
    {
        private readonly IAccountAppService _accountAppService;

        public AuthController(
            IAccountAppService accountAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _accountAppService = accountAppService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var response = await _accountAppService.Login(model);
            return Response(response);
        }

        [HttpPost("forgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            await _accountAppService.ForgotPassword(model);
            return Response();
        }

        [HttpPost("resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            await _accountAppService.ResetPassword(model);
            return Response();
        }

        [HttpPost("onboard")]
        public async Task<IActionResult> Onboard([FromBody] OnboardViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            await _accountAppService.Onboard(model);
            return Response();
        }

        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            await _accountAppService.UpdatePassword(model, int.Parse(userId));
            return Response();
        }
    }
}
