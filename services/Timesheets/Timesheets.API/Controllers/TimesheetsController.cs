using Timesheets.Application.Interfaces;
using Timesheets.Application.ViewModels;
using Timesheets.Domain.Bus;
using Timesheets.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Timesheets.Infrastructure.Requests;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Timesheets.Infrastructure.Helpers;

namespace Timesheets.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TimesheetsController : ApiController
    {
        private readonly ITimesheetsService _timesheetsService;
        //private readonly ILogger _logger;

        public TimesheetsController(
            ITimesheetsService timesheetsService,
            INotificationHandler<DomainNotification> notifications,
            //ILoggerFactory loggerFactory,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _timesheetsService = timesheetsService;
            //_logger = loggerFactory.CreateLogger<AuthController>();
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetTimesheets([FromQuery] GetTimesheetsViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (userId != model.UserId.ToString() && groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            if (model.End == DateTime.MinValue)
            {
                model.End = model.Start.AddDays(7);
            }

            var response = await _timesheetsService.GetTimesheets(model);
            return Response(response);
        }

        [HttpPost("{UserId}")]
        public async Task<IActionResult> AddTimesheet([FromRoute] int UserId, [FromBody] AddTimesheetViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (userId != UserId.ToString() && groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var response = await _timesheetsService.AddTimesheet(new TimesheetsRequest(UserId, model.Start, model.End, model.RemoteIpAddress));
            return Response(response);
        }

        [HttpPost("{UserId}/default")]
        public async Task<IActionResult> AddDefaultTimesheets([FromRoute] int UserId, [FromBody] AddTimesheetViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (userId != UserId.ToString() && groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var response = await _timesheetsService.AddDefaultTimesheet(new TimesheetsRequest(UserId, model.Start, model.End, model.RemoteIpAddress));
            return Response(response);
        }

        [HttpPut("{UserId}/{TimesheetId}")]
        public async Task<IActionResult> UpdateTimesheet([FromRoute] int UserId, [FromRoute] int TimesheetId, [FromBody] UpdateTimesheetViewModel model)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (userId != UserId.ToString() && groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var response = await _timesheetsService.UpdateTimesheet(new TimesheetsRequest(TimesheetId, UserId, model.Start, model.End, model.RemoteIpAddress));
            return Response(response);
        }

        [HttpDelete("{UserId}/{TimesheetId}")]
        public async Task<IActionResult> DeleteTimesheet([FromRoute] int UserId, [FromRoute] int TimesheetId)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (userId != UserId.ToString() && groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            await _timesheetsService.DeleteTimesheet(new TimesheetsRequest(UserId, TimesheetId));
            return Response();
        }
    }
}
