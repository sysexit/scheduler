using Templates.Domain.Interfaces;
using Templates.Infrastructure.Requests;
using Templates.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Templates.Infrastructure.Interfaces
{
    public interface IAddTemplateHandler
    {
        Task Handle(TemplatesRequest message, IOutputPort<TemplateResponse> outputPort);
    }
}
