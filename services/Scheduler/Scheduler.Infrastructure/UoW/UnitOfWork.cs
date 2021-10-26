using Scheduler.Domain.Interfaces;
using Scheduler.Infrastructure.Context;

namespace Scheduler.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScheduleContext _context;

        public UnitOfWork(ScheduleContext context)
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
