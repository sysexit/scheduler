using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Templates.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Templates.Infrastructure.Timesheets
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        //private readonly ILogger _logger;

        public JwtTokenHandler(/*ILogger logger*/)
        {
            if (_jwtSecurityTokenHandler == null)
                _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //_logger = logger;
        }

        public ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters)
        {
            try
            {
                var principal = _jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            catch (Exception e)
            {
                //_logger.LogError($"Token validation failed: {e.Message}");
                return null;
            }
        }
    }
}
