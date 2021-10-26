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
    public class OnboardHandler : CommandHandler, IOnboardHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public OnboardHandler(
            IUserRepository userRepository,
            ITokenRepository tokenRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _logger = loggerFactory.CreateLogger<LoginHandler>();
            Bus = bus;
        }

        public async Task Handle(OnboardRequest message)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid onboarding message from {0}.", message.Email);
                NotifyValidationErrors(message);
                return;
            }

            var existingUser = _userRepository.FindByEmail(message.Email);
            if (existingUser != null)
            {
                _logger.LogInformation("Onboarding request for existing email {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Email already in use."));
            }

            var newUser = new User(message.Email, message.First, message.Last, message.Positions); // TODO: Display name
            var uuid = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var newToken = new Token(message.Email, uuid);
            
            await _userRepository.AddAsync(newUser);
            await _tokenRepository.AddAsync(newToken);

            if (Commit())
            {
                _logger.LogInformation("Onboarded new user with email {0}.", message.Email);
                await Bus.RaiseEvent(new UserOnboardedEvent(uuid, message.Email, message.First, message.Last));
                return;
            }

            _logger.LogInformation("Error handling onboarding request for new user {0}.", message.Email);
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "User onboarding failed."));
        }
    }
}
