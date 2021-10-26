using Users.Application.Interfaces;
using Users.Application.Services;
using Users.Domain.Bus;
using Users.Domain.Interfaces;
using Users.Domain.Notifications;
using Users.Infrastructure.Timesheets;
using Users.Infrastructure.UserHandlers;
using Users.Infrastructure.Context;
using Users.Infrastructure.Interfaces;
using Users.Infrastructure.Interfaces.Services;
using Users.Infrastructure.Repositories;
using Users.Infrastructure.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Users.API.Configurations
{
    public class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<UsersContext>();

            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IGetUserHandler, GetUserHandler>();
            services.AddScoped<IUpdateUserHandler, UpdateUserHandler>();
            services.AddScoped<IUpdateUserStatusHandler, UpdateUserStatusHandler>();
            
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
        }
    }
}
