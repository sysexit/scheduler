using System.Security.Claims;

namespace Users.Infrastructure.Interfaces.Services
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
