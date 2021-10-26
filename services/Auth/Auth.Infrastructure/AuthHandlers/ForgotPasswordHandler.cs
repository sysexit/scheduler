using Auth.Domain.Bus;
using Auth.Domain.CommandHandlers;
using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Domain.Notifications;
using Auth.Infrastructure.Events;
using Auth.Infrastructure.Interfaces;
using Auth.Infrastructure.Requests;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Auth.Infrastructure.AuthHandlers
{
    public class ForgotPasswordHandler : CommandHandler, IForgotPasswordHandler
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public ForgotPasswordHandler(ILoginRepository loginRepository, 
            IUserRepository userRepository, 
            ITokenRepository tokenRepository, 
            ILoggerFactory loggerFactory, 
            IUnitOfWork uow, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _logger = loggerFactory.CreateLogger<LoginHandler>();
            Bus = bus;
        }

        public async Task Handle(ForgotPasswordRequest message)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid forgot password message from {0}.", message.Email);
                NotifyValidationErrors(message);
                return;
            }

            var user = _userRepository.FindByEmail(message.Email);
            if (user != null)
            {
                var existingToken = _tokenRepository.FindByEmail(message.Email);
                if (existingToken != null)
                {
                    _logger.LogInformation("Forgot password request from {0}.", message.Email);
                    await Bus.RaiseEvent(new ForgotPasswordEvent(existingToken.AccessToken, message.Email, message.First, message.Last));
                    return;
                }

                var uuid = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var newToken = new Token(message.Email, uuid);

                await _tokenRepository.AddAsync(newToken);
                if (Commit())
                {
                    _logger.LogInformation("Forgot password request from {0}.", message.Email);
                    await Bus.RaiseEvent(new ForgotPasswordEvent(uuid, message.Email, message.First, message.Last));
                    return;
                }

                // Only response with error if the user actually exists
                _logger.LogInformation("Error handling forgot password request from {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Something went wrong."));
            }
        }
    }
}
