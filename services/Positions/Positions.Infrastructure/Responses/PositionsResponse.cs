using Positions.Infrastructure.Dto;
using System.Collections.Generic;

namespace Positions.Infrastructure.Responses
{
    public class PositionsResponse
    {
        public List<Position> Positions { get; }

        public PositionsResponse(List<Position> timesheets)
        {
            Positions = timesheets;
        }

        public PositionsResponse(List<Domain.Entities.Position> positions)
        {
            List<Position> positionList = new List<Position>();
            foreach (Domain.Entities.Position position in positions) {
                var p = new Position(position.Id, position.Title);
                positionList.Add(p);
            }
            Positions = positionList;
        }

        public PositionsResponse(Domain.Entities.Position position)
        {
            List<Position> positionList = new List<Position>();
            var p = new Position(position.Id, position.Title);
            positionList.Add(p);
            Positions = positionList;
        }
    }
}
