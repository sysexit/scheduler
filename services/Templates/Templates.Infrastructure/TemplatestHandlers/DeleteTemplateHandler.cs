using Templates.Domain.Bus;
using Templates.Domain.CommandHandlers;
using Templates.Domain.Interfaces;
using Templates.Domain.Notifications;
using Templates.Infrastructure.Interfaces;
using Templates.Infrastructure.Requests;
using MediatR;
using System.Threading.Tasks;

namespace Templates.Infrastructure.TimesheetHandlers
{
    public class DeleteTemplateHandler : CommandHandler, IDeleteTemplateHandler
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMediatorHandler Bus;

        public DeleteTemplateHandler(ITemplateRepository templateRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _templateRepository = templateRepository;
            Bus = bus;
        }

        public async Task Handle(TemplatesRequest message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var template = _templateRepository.FindByIdAsync(message.Id);
            if (template.Result != null)
            {
                _templateRepository.Remove(message.Id);

                if (Commit())
                {
                    return;
                }
            }

            await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Removing template failed"));
        }
    }
}
