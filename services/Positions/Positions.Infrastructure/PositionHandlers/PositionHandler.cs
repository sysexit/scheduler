using Positions.Domain.Bus;
using Positions.Domain.CommandHandlers;
using Positions.Domain.Interfaces;
using Positions.Domain.Notifications;
using Positions.Infrastructure.Interfaces;
using Positions.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;
using System.Linq;
using Positions.Infrastructure.Dto;

namespace Positions.Infrastructure.PositionHandlers
{
    public class PositionHandler : CommandHandler, IPositionHandler
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMediatorHandler Bus;

        public PositionHandler(IPositionRepository positionRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _positionRepository = positionRepository;
            Bus = bus;
        }

        public async Task Handle(IOutputPort<PositionsResponse> outputPort)
        {
            var templates = _positionRepository.GetAll().ToList();
            outputPort.Handle(new PositionsResponse(templates));
            return;
        }
    }
}
