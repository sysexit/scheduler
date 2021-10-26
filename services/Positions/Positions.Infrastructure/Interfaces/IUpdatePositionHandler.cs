using Positions.Infrastructure.Requests;
using System.Threading.Tasks;
using Positions.Infrastructure.Responses;
using Positions.Domain.Interfaces;

namespace Positions.Infrastructure.Interfaces
{
    public interface IUpdatePositionHandler
    {
        Task Handle(PositionsRequest message, IOutputPort<PositionResponse> outputPort);
    }
}
