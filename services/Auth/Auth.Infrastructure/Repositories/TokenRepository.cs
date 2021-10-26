using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Context;
using System.Linq;

namespace Auth.Infrastructure.Repositories
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        private readonly AuthContext _context;

        public TokenRepository(AuthContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public Token FindByEmail(string email)
        {
            return _context.Token.FirstOrDefault(l => l.Email == email);
        }

        public Token GetToken(string token)
        {
            return DbSet.FirstOrDefault(t => t.AccessToken.Equals(token));
        }

        public void DeleteToken(Token token)
        {
            DbSet.Remove(token);
        }
    }
}
