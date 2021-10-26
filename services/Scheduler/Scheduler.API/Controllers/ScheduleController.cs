using Scheduler.Application.Interfaces;
using Scheduler.Application.ViewModels;
using Scheduler.Domain.Bus;
using Scheduler.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Scheduler.Infrastructure.Helpers;

namespace Scheduler.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : ApiController
    {
        private readonly IScheduleService _scheduleService;
        //private readonly ILogger _logger;

        public ScheduleController(
            IScheduleService timesheetsService,
            INotificationHandler<DomainNotification> notifications,
            //ILoggerFactory loggerFactory,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _scheduleService = timesheetsService;
            //_logger = loggerFactory.CreateLogger<AuthController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedule([FromQuery] GetScheduleViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            //if (!ModelState.IsValid)
            //{
            //    NotifyModelStateErrors();
            //    return Response(model);
            //}

            var response = await _scheduleService.GetSchedule(int.Parse(groupId), model);
            return Response(new { schedule = response.Schedules });
        }

        [HttpPost("publish")]
        public async Task<IActionResult> PublishSchedule(PublishScheduleViewModel model)
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

            await _scheduleService.PublishSchedule(model);
            return Response();
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule([FromBody] AddScheduleViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
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

            var response = await _scheduleService.AddSchedule(model);
            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchedule([FromBody] UpdateScheduleViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
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

            var response = await _scheduleService.UpdateSchedule(model);
            return Response(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchedule([FromBody] DeleteScheduleViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            await _scheduleService.DeleteTimesheet(model);
            return Response();
        }
    }
}
