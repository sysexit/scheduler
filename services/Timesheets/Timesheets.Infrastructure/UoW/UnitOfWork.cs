using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Context;

namespace Timesheets.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimesheetsContext _context;

        public UnitOfWork(TimesheetsContext context)
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
