using Auth.Application.Interfaces;
using Auth.Application.Services;
using Auth.Domain.Bus;
using Auth.Domain.Interfaces;
using Auth.Domain.Notifications;
using Auth.Infrastructure.Auth;
using Auth.Infrastructure.AuthHandlers;
using Auth.Infrastructure.Context;
using Auth.Infrastructure.EventHandler;
using Auth.Infrastructure.Events;
using Auth.Infrastructure.Interfaces;
using Auth.Infrastructure.Interfaces.Services;
using Auth.Infrastructure.Repositories;
using Auth.Infrastructure.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.API.Configurations
{
    public class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IAccountAppService, AccountAppService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserOnboardedEvent>, UserOnboardedEventHandler>();
            services.AddScoped<INotificationHandler<ForgotPasswordEvent>, ForgotPasswordEventHandler>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AuthContext>();

            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IOnboardHandler, OnboardHandler>();
            services.AddScoped<IForgotPasswordHandler, ForgotPasswordHandler>();
            services.AddScoped<IResetPasswordHandler, ResetPasswordHandler>();
            services.AddScoped<IUpdatePasswordHandler, UpdatePasswordHandler>();

            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
        }
    }
}
