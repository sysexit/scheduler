using Users.Application.Interfaces;
using Users.Application.ViewModels;
using Users.Domain.Bus;
using Users.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Users.Infrastructure.Helpers;

namespace Users.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        //private readonly ILogger _logger;

        public UsersController(
            IUserService timesheetsService,
            INotificationHandler<DomainNotification> notifications,
            //ILoggerFactory loggerFactory,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _userService = timesheetsService;
            //_logger = loggerFactory.CreateLogger<AuthController>();
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;

            var response = await _userService.GetUser(int.Parse(userId));
            return Response(response.User);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if ((model.Type == Infrastructure.Requests.UserRequestType.ALL ||
                model.Type == Infrastructure.Requests.UserRequestType.ENABLED) &&
                groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            var response = await _userService.GetUsers(model);
            return Response(response);
        }

        [HttpPut("user")]
        public async Task<IActionResult> AdminUpdateUser([FromBody] UpdateUserViewModel model)
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

            await _userService.UpdateUser(model);
            return Response();
        }

        [HttpPut("user/status")]
        public async Task<IActionResult> UpdateUserStatus([FromBody] UpdateUserStatusViewModel model)
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

            await _userService.UpdateUserStatus(model);
            return Response();
        }
    }
}
