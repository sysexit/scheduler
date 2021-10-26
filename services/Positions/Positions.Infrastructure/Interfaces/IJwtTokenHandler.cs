using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Positions.Infrastructure.Interfaces
{
    public interface IJwtTokenHandler
    {
        ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters);
    }
}
