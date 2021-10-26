using Scheduler.Application.Interfaces;
using Scheduler.Application.Services;
using Scheduler.Domain.Bus;
using Scheduler.Domain.Interfaces;
using Scheduler.Domain.Notifications;
using Scheduler.Infrastructure.Timesheets;
using Scheduler.Infrastructure.TimesheetHandlers;
using Scheduler.Infrastructure.Context;
using Scheduler.Infrastructure.Interfaces;
using Scheduler.Infrastructure.Interfaces.Services;
using Scheduler.Infrastructure.Repositories;
using Scheduler.Infrastructure.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Scheduler.API.Configurations
{
    public class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IScheduleService, ScheduleService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ScheduleContext>();

            services.AddScoped<IScheduleHandler, ScheduleHandler>();
            services.AddScoped<IPublishScheduleHandler, PublishScheduleHandler>();
            services.AddScoped<IAddScheduleHandler, AddScheduleHandler>();
            services.AddScoped<IUpdateScheduleHandler, UpdateScheduleHandler>();
            services.AddScoped<IDeleteScheduleHandler, DeleteScheduleHandler>();
            
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
        }
    }
}
