using Positions.Domain.Interfaces;
using Positions.Infrastructure.Context;

namespace Positions.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PositionsContext _context;

        public UnitOfWork(PositionsContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
