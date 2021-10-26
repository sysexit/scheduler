using Templates.Domain.Interfaces;
using Templates.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Templates.Infrastructure.Interfaces
{
    public interface ITemplatesHandler
    {
        Task Handle(IOutputPort<TemplatesResponse> outputPort);
    }
}
