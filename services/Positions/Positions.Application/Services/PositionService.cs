using Positions.Application.Interfaces;
using Positions.Application.ViewModels;
using Positions.Infrastructure.Interfaces;
using Positions.Infrastructure.Presenters;
using Positions.Infrastructure.Requests;
using Positions.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Positions.Application.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionHandler _positionHandler;
        private readonly IAddPositionHandler _addPositionHandler;
        private readonly IUpdatePositionHandler _updatePositionHandler;
        private readonly PositionsPresenter _positionsPresenter;
        private readonly PositionPresenter _positionPresenter;

        public PositionService(IPositionHandler positionHandler, IAddPositionHandler addPositionHandler, IUpdatePositionHandler updatePositionHandler)
        {
            _positionHandler = positionHandler;
            _addPositionHandler = addPositionHandler;
            _updatePositionHandler = updatePositionHandler;
            _positionsPresenter = new PositionsPresenter();
            _positionPresenter = new PositionPresenter();
        }

        public async Task<PositionsResponse> GetPositions()
        {
            await _positionHandler.Handle(_positionsPresenter);
            return _positionsPresenter.data;
        }

        public async Task<PositionResponse> AddPosition(AddPositionViewModel model)
        {
            await _addPositionHandler.Handle(new PositionsRequest(model.Title), _positionPresenter);
            return _positionPresenter.data;
        }

        public async Task<PositionResponse> UpdatePosition(UpdatePositionViewModel model)
        {
            await _updatePositionHandler.Handle(new PositionsRequest(model.Id, model.Title), _positionPresenter);
            return _positionPresenter.data;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
