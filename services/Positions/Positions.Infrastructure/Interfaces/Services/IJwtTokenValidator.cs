using System.Security.Claims;

namespace Positions.Infrastructure.Interfaces.Services
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
