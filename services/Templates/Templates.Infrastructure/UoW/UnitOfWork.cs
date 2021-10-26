using Templates.Domain.Interfaces;
using Templates.Infrastructure.Context;

namespace Templates.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TemplatesContext _context;

        public UnitOfWork(TemplatesContext context)
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
