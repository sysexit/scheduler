using Templates.Application.Interfaces;
using Templates.Application.Services;
using Templates.Domain.Bus;
using Templates.Domain.Interfaces;
using Templates.Domain.Notifications;
using Templates.Infrastructure.Timesheets;
using Templates.Infrastructure.TimesheetHandlers;
using Templates.Infrastructure.Context;
using Templates.Infrastructure.Interfaces;
using Templates.Infrastructure.Interfaces.Services;
using Templates.Infrastructure.Repositories;
using Templates.Infrastructure.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Templates.API.Configurations
{
    public class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<ITemplateService, TemplatesService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TemplatesContext>();

            services.AddScoped<ITemplatesHandler, TemplatesHandler>();
            services.AddScoped<IAddTemplateHandler, AddTemplateHandler>();
            services.AddScoped<IUpdateTemplateHandler, UpdateTemplateHandler>();
            services.AddScoped<IDeleteTemplateHandler, DeleteTemplateHandler>();
            
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
        }
    }
}
