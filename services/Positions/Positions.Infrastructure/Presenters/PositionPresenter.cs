using Positions.Domain.Interfaces;
using Positions.Infrastructure.Responses;

namespace Positions.Infrastructure.Presenters
{
    public sealed class PositionPresenter : IOutputPort<PositionResponse>
    {
        public PositionResponse data { get; set; }

        public void Handle(PositionResponse response)
        {
            data = response;
        }
    }
}
