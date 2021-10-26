using Auth.Domain.Bus;
using Auth.Domain.CommandHandlers;
using Auth.Domain.Interfaces;
using Auth.Domain.Notifications;
using Auth.Infrastructure.Interfaces;
using Auth.Infrastructure.Requests;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Auth.Infrastructure.AuthHandlers
{
    public class ResetPasswordHandler : CommandHandler, IResetPasswordHandler
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public ResetPasswordHandler(ILoginRepository loginRepository,
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

        public async Task Handle(ResetPasswordRequest message)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid reset password message from {0}.", message.Email);
                NotifyValidationErrors(message);
                return;
            }

            var token = _tokenRepository.GetToken(message.Token);
            if (token == null || !token.Email.Equals(message.Email))
            {
                _logger.LogInformation("Invalid reset password token from {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Invalid token."));
                return;
            }

            var user = _userRepository.FindByEmail(message.Email);
            var login = _loginRepository.FindByEmail(message.Email);

            // Account exists and has a logon
            if (login == null || user == null)
            {
                _logger.LogInformation("Invalid reset password request for nill account {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Account does not exist."));
                return;
            }

            if (!login.Enabled)
            {
                _logger.LogInformation("Password reset attempt for disabled account {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Account is disabled."));
                return;
            }

            login.PasswordHash = BCrypt.Net.BCrypt.HashPassword(message.Password);
            _loginRepository.Update(login);
            _tokenRepository.DeleteToken(token);

            if (Commit())
            {
                _logger.LogInformation("Password reset for {0}.", message.Email);
                return;
            }

            _logger.LogInformation("Error handling password reset request for user {0}.", message.Email);
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Password reset failed."));
        }
    }
}
