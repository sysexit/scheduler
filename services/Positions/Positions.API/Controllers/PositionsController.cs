using Positions.Application.Interfaces;
using Positions.Application.ViewModels;
using Positions.Domain.Bus;
using Positions.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Positions.Infrastructure.Helpers;

namespace Positions.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PositionsController : ApiController
    {
        private readonly IPositionService _positionService;
        //private readonly ILogger _logger;

        public PositionsController(
            IPositionService timesheetsService,
            INotificationHandler<DomainNotification> notifications,
            //ILoggerFactory loggerFactory,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _positionService = timesheetsService;
            //_logger = loggerFactory.CreateLogger<AuthController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetPositions()
        {
            var response = await _positionService.GetPositions();
            return Response(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPosition([FromBody] AddPositionViewModel model)
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

            var response = await _positionService.AddPosition(model);
            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePosition([FromBody] UpdatePositionViewModel model)
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

            var response = await _positionService.UpdatePosition(model);
            return Response(response);
        }
    }
}
