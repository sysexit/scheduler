using Positions.Application.Interfaces;
using Positions.Application.Services;
using Positions.Domain.Bus;
using Positions.Domain.Interfaces;
using Positions.Domain.Notifications;
using Positions.Infrastructure.Timesheets;
using Positions.Infrastructure.PositionHandlers;
using Positions.Infrastructure.Context;
using Positions.Infrastructure.Interfaces;
using Positions.Infrastructure.Interfaces.Services;
using Positions.Infrastructure.Repositories;
using Positions.Infrastructure.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Positions.API.Configurations
{
    public class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PositionsContext>();

            services.AddScoped<IPositionHandler, PositionHandler>();
            services.AddScoped<IAddPositionHandler, AddPositionHandler>();
            services.AddScoped<IUpdatePositionHandler, UpdatePositionHandler>();

            services.AddScoped<IPositionRepository, PositionsRepository>();
            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
        }
    }
}
