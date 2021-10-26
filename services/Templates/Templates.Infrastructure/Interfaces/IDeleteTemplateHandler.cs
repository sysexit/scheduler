using Templates.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Templates.Infrastructure.Interfaces
{
    public interface IDeleteTemplateHandler
    {
        Task Handle(TemplatesRequest message);
    }
}
