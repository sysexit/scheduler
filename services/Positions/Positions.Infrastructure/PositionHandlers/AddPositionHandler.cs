using Positions.Domain.Bus;
using Positions.Domain.CommandHandlers;
using Positions.Domain.Interfaces;
using Positions.Domain.Notifications;
using Positions.Infrastructure.Interfaces;
using Positions.Infrastructure.Requests;
using Positions.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;

namespace Positions.Infrastructure.PositionHandlers
{
    public class AddPositionHandler : CommandHandler, IAddPositionHandler
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMediatorHandler Bus;

        public AddPositionHandler(IPositionRepository positionRepository,
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

            var template = new Domain.Entities.Position(message.Title);
            await _positionRepository.AddAsync(template);

            if (Commit())
            {
                outputPort.Handle(new PositionResponse(template));
                return;
            }

            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Adding position failed"));
        }
    }
}
