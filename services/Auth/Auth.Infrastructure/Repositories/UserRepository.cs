using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Context;
using System.Linq;

namespace Auth.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AuthContext _context;

        public UserRepository(AuthContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public User FindByEmail(string email)
        {
            return _context.User.FirstOrDefault(l => l.Email == email);
        }
    }
}
