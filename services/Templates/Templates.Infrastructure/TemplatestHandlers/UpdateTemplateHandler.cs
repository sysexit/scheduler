using Templates.Domain.Bus;
using Templates.Domain.CommandHandlers;
using Templates.Domain.Interfaces;
using Templates.Domain.Notifications;
using Templates.Infrastructure.Interfaces;
using Templates.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;
using Templates.Infrastructure.Responses;

namespace Templates.Infrastructure.TimesheetHandlers
{
    public class UpdateTemplateHandler : CommandHandler, IUpdateTemplateHandler
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMediatorHandler Bus;

        public UpdateTemplateHandler(ITemplateRepository templateRepository,
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

            var template = new Domain.Entities.Template(message.Id, message.Start, message.End, message.Position);
            _templateRepository.Update(template);

            if (Commit())
            {
                outputPort.Handle(new TemplateResponse(template));
                return;
            }

            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Updating template failed"));
        }
    }
}
