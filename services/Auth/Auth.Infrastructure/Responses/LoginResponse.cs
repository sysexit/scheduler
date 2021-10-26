using Auth.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Responses
{
    public class LoginResponse
    {
        public AccessToken AccessToken { get; }

        public LoginResponse(AccessToken accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
