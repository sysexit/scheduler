using Positions.Domain.Bus;
using Positions.Domain.CommandHandlers;
using Positions.Domain.Interfaces;
using Positions.Domain.Notifications;
using Positions.Infrastructure.Interfaces;
using Positions.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;
using Positions.Infrastructure.Responses;

namespace Positions.Infrastructure.PositionHandlers
{
    public class UpdatePositionHandler : CommandHandler, IUpdatePositionHandler
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMediatorHandler Bus;

        public UpdatePositionHandler(IPositionRepository positionRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _positionRepository = positionRepository;
            Bus = bus;
        }

        public async Task Handle(PositionsRequest message, IOutputPort<PositionResponse> outputPort)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var template = new Domain.Entities.Position(message.Id, message.Title);
            _positionRepository.Update(template);

            if (Commit())
            {
                outputPort.Handle(new PositionResponse(template));
                return;
            }

            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Updating position failed"));
        }
    }
}
