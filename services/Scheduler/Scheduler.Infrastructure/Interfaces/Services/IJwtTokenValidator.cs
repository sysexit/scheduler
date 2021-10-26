using System.Security.Claims;

namespace Scheduler.Infrastructure.Interfaces.Services
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
