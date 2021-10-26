using Users.Domain.Entities;
using Users.Domain.Interfaces;
using Users.Infrastructure.Context;
using System.Linq;

namespace Users.Infrastructure.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        private readonly UsersContext _context;

        public LoginRepository(UsersContext usersContext) : base(usersContext)
        {
            _context = usersContext;
        }

        public Login FindByEmail(string email)
        {
            return _context.Logins.FirstOrDefault(l => l.Email == email);
        }
    }
}
