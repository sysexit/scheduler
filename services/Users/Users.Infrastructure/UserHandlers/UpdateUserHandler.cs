using Users.Domain.Bus;
using Users.Domain.CommandHandlers;
using Users.Domain.Interfaces;
using Users.Domain.Notifications;
using Users.Infrastructure.Interfaces;
using Users.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;
using Users.Infrastructure.Responses;

namespace Users.Infrastructure.UserHandlers
{
    public class UpdateUserHandler : CommandHandler, IUpdateUserHandler
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMediatorHandler Bus;

        public UpdateUserHandler(IUsersRepository scheduleRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _userRepository = scheduleRepository;
            Bus = bus;
        }

        public async Task Handle(UsersRequest message, IOutputPort<UserResponse> outputPort)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var existingUser = _userRepository.FindById(message.Id);

            if (existingUser == null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "User does not exist"));
                return;
            }

            existingUser.First = message.First;
            existingUser.Last = message.Last;
            existingUser.Positions = message.Positions;
            existingUser.Display = message.Display;

            _userRepository.Update(existingUser);

            if (Commit())
            {
                return;
            }

            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Updating user failed"));
        }
    }
}
