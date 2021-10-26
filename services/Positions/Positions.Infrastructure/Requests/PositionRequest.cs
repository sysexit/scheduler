using System;
using Positions.Domain.Commands;

namespace Positions.Infrastructure.Requests
{
    public abstract class PositionRequest : Command
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
