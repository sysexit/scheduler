using Auth.Infrastructure.Dto;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Interfaces
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName, string group);
    }
}
