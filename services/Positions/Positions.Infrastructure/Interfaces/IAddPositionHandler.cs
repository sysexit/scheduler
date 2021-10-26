using Positions.Domain.Interfaces;
using Positions.Infrastructure.Requests;
using Positions.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Positions.Infrastructure.Interfaces
{
    public interface IAddPositionHandler
    {
        Task Handle(PositionsRequest message, IOutputPort<PositionResponse> outputPort);
    }
}
