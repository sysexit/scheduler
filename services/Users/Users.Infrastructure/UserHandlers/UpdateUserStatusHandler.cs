using Users.Domain.Bus;
using Users.Domain.CommandHandlers;
using Users.Domain.Interfaces;
using Users.Domain.Notifications;
using Users.Infrastructure.Interfaces;
using Users.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;

namespace Users.Infrastructure.UserHandlers
{
    public class UpdateUserStatusHandler : CommandHandler, IUpdateUserStatusHandler
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMediatorHandler Bus;

        public UpdateUserStatusHandler(ILoginRepository loginRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _loginRepository = loginRepository;
            Bus = bus;
        }

        public async Task Handle(UserStatusRequest message)
        {
            //if (!message.IsValid())
            //{
            //    NotifyValidationErrors(message);
            //    return;
            //}

            var user = _loginRepository.FindByEmail(message.Email);
            if (user != null)
            {
                if (user.Enabled == message.Enabled)
                {
                    return;
                }

                user.Enabled = message.Enabled;
                _loginRepository.Update(user);

                if (Commit())
                {
                    return;
                }
            }

            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Updating user failed"));
        }
    }
}
