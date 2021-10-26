using Users.Domain.Interfaces;
using Users.Infrastructure.Context;

namespace Users.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsersContext _context;

        public UnitOfWork(UsersContext context)
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
