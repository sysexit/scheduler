using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Positions.Domain.Entities;

namespace Positions.Domain.Interfaces
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<Position> FindByIdAsync(int id);
    }
}
