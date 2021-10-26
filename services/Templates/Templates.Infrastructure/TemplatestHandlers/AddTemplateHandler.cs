using Templates.Domain.Bus;
using Templates.Domain.CommandHandlers;
using Templates.Domain.Interfaces;
using Templates.Domain.Notifications;
using Templates.Infrastructure.Interfaces;
using Templates.Infrastructure.Requests;
using Templates.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;

namespace Templates.Infrastructure.TimesheetHandlers
{
    public class AddTemplateHandler : CommandHandler, IAddTemplateHandler
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMediatorHandler Bus;

        public AddTemplateHandler(ITemplateRepository templateRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _templateRepository = templateRepository;
            Bus = bus;
        }

        public async Task Handle(TemplatesRequest message, IOutputPort<TemplateResponse> outputPort)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var template = new Domain.Entities.Template(message.Start, message.End, message.Position);
            await _templateRepository.AddAsync(template);

            if (Commit())
            {
                outputPort.Handle(new TemplateResponse(template));
                return;
            }

            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Adding template failed"));
        }
    }
}
