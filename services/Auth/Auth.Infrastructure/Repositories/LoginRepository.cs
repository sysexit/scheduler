using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Context;
using System.Linq;

namespace Auth.Infrastructure.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        private readonly AuthContext _context;

        public LoginRepository(AuthContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public bool CheckPassword(Login login, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, login.PasswordHash);
        }

        public Login FindByEmail(string email)
        {
            return _context.Login.FirstOrDefault(l => l.Email == email);
        }
    }
}
