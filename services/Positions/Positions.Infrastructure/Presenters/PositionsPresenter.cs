using Positions.Domain.Interfaces;
using Positions.Infrastructure.Responses;

namespace Positions.Infrastructure.Presenters
{
    public sealed class PositionsPresenter : IOutputPort<PositionsResponse>
    {
        public PositionsResponse data { get; set; }

        public void Handle(PositionsResponse response)
        {
            data = response;
        }
    }
}
