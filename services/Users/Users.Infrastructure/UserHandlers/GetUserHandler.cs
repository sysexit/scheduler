using Users.Domain.Bus;
using Users.Domain.CommandHandlers;
using Users.Domain.Interfaces;
using Users.Domain.Notifications;
using Users.Infrastructure.Interfaces;
using Users.Infrastructure.Requests;
using Users.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;

namespace Users.Infrastructure.UserHandlers
{
    public class GetUserHandler : CommandHandler, IGetUserHandler
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMediatorHandler Bus;

        public GetUserHandler(IUsersRepository scheduleRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _usersRepository = scheduleRepository;
            Bus = bus;
        }

        public async Task Handle(UsersRequest message, IOutputPort<UserResponse> outputPort)
        {
            //if (!message.IsValid())
            //{
            //    NotifyValidationErrors(message);
            //    return;
            //}

            var user = _usersRepository.DtoUserById(message.Id);

            if (user == null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "An error occured while retrieving user."));
            }

            outputPort.Handle(new UserResponse(user));
        }
    }
}
