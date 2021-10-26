using Templates.Application.Interfaces;
using Templates.Application.ViewModels;
using Templates.Domain.Bus;
using Templates.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Templates.Infrastructure.Requests;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Templates.Infrastructure.Helpers;

namespace Templates.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TemplatesController : ApiController
    {
        private readonly ITemplateService _templatesService;
        //private readonly ILogger _logger;

        public TemplatesController(
            ITemplateService timesheetsService,
            INotificationHandler<DomainNotification> notifications,
            //ILoggerFactory loggerFactory,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _templatesService = timesheetsService;
            //_logger = loggerFactory.CreateLogger<AuthController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetTimesheets()
        {
            var response = await _templatesService.GetTemplates();
            return Response(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTimesheet([FromBody] AddTemplateViewModel model)
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

            var response = await _templatesService.AddTemplate(model);
            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTimesheet([FromBody] UpdateTemplateViewModel model)
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

            var response = await _templatesService.UpdateTemplate(model);
            return Response(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTimesheet([FromRoute] int TemplateId)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var groupId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Group).Value;

            if (groupId != Constants.Strings.JwtClaims.Admin)
            {
                return Forbid();
            }

            await _templatesService.DeleteTemplate(TemplateId);
            return Response();
        }
    }
}
