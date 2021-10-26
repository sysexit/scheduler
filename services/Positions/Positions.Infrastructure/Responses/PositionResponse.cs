using Positions.Infrastructure.Dto;

namespace Positions.Infrastructure.Responses
{
    public class PositionResponse
    {
        public Position Position { get; }

        public PositionResponse(Domain.Entities.Position position)
        {
            Position = new Position(position.Id, position.Title);
        }
    }
}
