using Auth.Domain.Interfaces;
using Auth.Infrastructure.Context;

namespace Auth.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthContext _context;

        public UnitOfWork(AuthContext context)
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
