using Auth.Domain.Entities;
using System.Threading.Tasks;

namespace Auth.Domain.Interfaces
{
    public interface ITokenRepository : IRepository<Token>
    {
        Token FindByEmail(string email);
        Token GetToken(string token);
        void DeleteToken(Token token);
    }
}
