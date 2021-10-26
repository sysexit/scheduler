using Positions.Domain.Entities;
using Positions.Domain.Interfaces;
using Positions.Infrastructure.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Positions.Infrastructure.Repositories
{
    public class PositionsRepository : Repository<Position>, IPositionRepository
    {
        private readonly PositionsContext _context;

        public PositionsRepository(PositionsContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public Task<Position> FindByIdAsync(int id)
        {
            return _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
