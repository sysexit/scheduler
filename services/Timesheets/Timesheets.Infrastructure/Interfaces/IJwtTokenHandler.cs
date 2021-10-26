using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Timesheets.Infrastructure.Interfaces
{
    public interface IJwtTokenHandler
    {
        ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters);
    }
}
