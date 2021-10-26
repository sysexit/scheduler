using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Users.Infrastructure.Interfaces
{
    public interface IJwtTokenHandler
    {
        ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters);
    }
}
