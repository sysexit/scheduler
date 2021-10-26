using Positions.Application.ViewModels;
using Positions.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Positions.Application.Interfaces
{
    public interface IPositionService : IDisposable
    {
        Task<PositionsResponse> GetPositions();
        Task<PositionResponse> AddPosition(AddPositionViewModel model);
        Task<PositionResponse> UpdatePosition(UpdatePositionViewModel model);
    }
}
