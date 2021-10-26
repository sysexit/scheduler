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
    public class UserHandler : CommandHandler, IUserHandler
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMediatorHandler Bus;

        public UserHandler(IUsersRepository scheduleRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _usersRepository = scheduleRepository;
            Bus = bus;
        }

        public async Task Handle(UserListRequest message, IOutputPort<UsersResponse> outputPort)
        {
            //if (!message.IsValid())
            //{
            //    NotifyValidationErrors(message);
            //    return;
            //}

            switch (message.Type)
            {
                case UserRequestType.ALL:
                    outputPort.Handle(new UsersResponse(await _usersRepository.FindAllUsersAsync()));
                    break;
                case UserRequestType.ENABLED:
                    outputPort.Handle(new UsersResponse(await _usersRepository.FindEnabledUsersAsync()));
                    break;
                case UserRequestType.SCHEDULE:
                    outputPort.Handle(new UsersResponse(await _usersRepository.FindScheduleUsersAsync()));
                    break;
            }
        }
    }
}
