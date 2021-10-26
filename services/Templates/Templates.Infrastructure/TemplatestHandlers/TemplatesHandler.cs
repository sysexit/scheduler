using Templates.Domain.Bus;
using Templates.Domain.CommandHandlers;
using Templates.Domain.Interfaces;
using Templates.Domain.Notifications;
using Templates.Infrastructure.Interfaces;
using Templates.Infrastructure.Responses;
using MediatR;
using System.Threading.Tasks;
using System.Linq;
using Templates.Infrastructure.Dto;

namespace Templates.Infrastructure.TimesheetHandlers
{
    public class TemplatesHandler : CommandHandler, ITemplatesHandler
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMediatorHandler Bus;

        public TemplatesHandler(ITemplateRepository templateRepository,
                            IUnitOfWork uow,
                            IMediatorHandler bus,
                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _templateRepository = templateRepository;
            Bus = bus;
        }

        public async Task Handle(IOutputPort<TemplatesResponse> outputPort)
        {
            var templates = _templateRepository.GetAll().ToList();
            outputPort.Handle(new TemplatesResponse(templates));
            return;
        }
    }
}
