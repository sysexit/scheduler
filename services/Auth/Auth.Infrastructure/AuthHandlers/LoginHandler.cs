using Auth.Domain.Bus;
using Auth.Domain.CommandHandlers;
using Auth.Domain.Interfaces;
using Auth.Domain.Notifications;
using Auth.Infrastructure.Interfaces;
using Auth.Infrastructure.Requests;
using Auth.Infrastructure.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Auth.Infrastructure.AuthHandlers
{
    public class LoginHandler : CommandHandler, ILoginHandler
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly IJwtFactory _jwtFactory;
        private readonly IMediatorHandler Bus;

        public LoginHandler(ILoginRepository loginRepository,
            IUserRepository userRepository,
            IJwtFactory jwtFactory,
            ILoggerFactory loggerFactory,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _logger = loggerFactory.CreateLogger<LoginHandler>();
            _jwtFactory = jwtFactory;
            Bus = bus;
        }

        public async Task Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!message.IsValid())
            {
                _logger.LogInformation("Invalid login message from {0}.", message.Email);
                NotifyValidationErrors(message);
                return;
            }

            var user = _userRepository.FindByEmail(message.Email);
            var login = _loginRepository.FindByEmail(message.Email);

            if (login != null && user != null)
            {
                if (!login.Enabled)
                {
                    _logger.LogInformation("Disable account login attempt for {0}.", message.Email);
                    await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Account is disabled"));
                    return;
                }

                if (_loginRepository.CheckPassword(login, message.Password))
                {
                    _logger.LogInformation("User {0} successfully logged in.", message.Email);
                    outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id.ToString(), login.Email, login.Group.ToString())));
                    return;
                }
            }

            _logger.LogInformation("Invalid login attempt for {0}.", message.Email);
            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Email/password is invalid"));
        }
    }
}
