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
    public class UpdatePasswordHandler : CommandHandler, IUpdatePasswordHandler
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly IMediatorHandler Bus;

        public UpdatePasswordHandler(ILoginRepository loginRepository,
            IUserRepository userRepository,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _logger = loggerFactory.CreateLogger<LoginHandler>();
            Bus = bus;
        }

        public async Task Handle(UpdatePasswordRequest message)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid update password message from {0}.", message.Email);
                NotifyValidationErrors(message);
                return;
            }

            var user = await _userRepository.GetByIDAsync(message.Id);
            if (user == null)
            {
                _logger.LogInformation("Invalid update password request for nill account {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Account does not exist."));
                return;
            }

            var login = _loginRepository.FindByEmail(user.Email);
            if (login == null)
            {
                _logger.LogInformation("Invalid update password request for nill logon {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Account does not exist."));
                return;
            }

            if (!login.Enabled)
            {
                _logger.LogInformation("Update password attempt for disabled account {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Account is disabled"));
                return;
            }

            if (!_loginRepository.CheckPassword(login, message.CurrentPassword))
            {
                _logger.LogInformation("Invalid current password for password update request from {0}.", message.Email);
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Incorrect current password."));
                return;
            }

            login.PasswordHash = BCrypt.Net.BCrypt.HashPassword(message.Password);
            _loginRepository.Update(login);

            if (Commit())
            {
                _logger.LogInformation("Password updated for {0}.", message.Email);
                return;
            }

            _logger.LogInformation("Error handling password update request for user {0}.", message.Email);
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Password updating failed."));
        }
    }
}
