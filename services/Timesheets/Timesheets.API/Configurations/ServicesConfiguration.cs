using Timesheets.Application.Interfaces;
using Timesheets.Application.Services;
using Timesheets.Domain.Bus;
using Timesheets.Domain.Interfaces;
using Timesheets.Domain.Notifications;
using Timesheets.Infrastructure.Timesheets;
using Timesheets.Infrastructure.TimesheetHandlers;
using Timesheets.Infrastructure.Context;
using Timesheets.Infrastructure.Interfaces;
using Timesheets.Infrastructure.Interfaces.Services;
using Timesheets.Infrastructure.Repositories;
using Timesheets.Infrastructure.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Timesheets.API.Configurations
{
    public class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<ITimesheetsService, TimesheetsService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TimesheetsContext>();

            services.AddScoped<ITimesheetsHandler, TimesheetsHandler>();
            services.AddScoped<IAddTimesheetHandler, AddTimesheetHandler>();
            services.AddScoped<IAddDefaultTimesheetHandler, AddDefaultTimesheetHandler>();
            services.AddScoped<IUpdateTimesheetHandler, UpdateTimesheetHandler>();
            services.AddScoped<IDeleteTimesheetHandler, DeleteTimesheetHandler>();
            
            services.AddScoped<ITimesheetRepository, TimesheetRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
        }
    }
}
