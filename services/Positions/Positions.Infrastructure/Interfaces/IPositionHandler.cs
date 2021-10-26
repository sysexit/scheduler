using Positions.Domain.Interfaces;
using Positions.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Positions.Infrastructure.Interfaces
{
    public interface IPositionHandler
    {
        Task Handle(IOutputPort<PositionsResponse> outputPort);
    }
}
