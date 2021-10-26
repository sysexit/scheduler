using Templates.Infrastructure.Requests;
using System.Threading.Tasks;
using Templates.Infrastructure.Responses;
using Templates.Domain.Interfaces;

namespace Templates.Infrastructure.Interfaces
{
    public interface IUpdateTemplateHandler
    {
        Task Handle(TemplatesRequest message, IOutputPort<TemplateResponse> outputPort);
    }
}
