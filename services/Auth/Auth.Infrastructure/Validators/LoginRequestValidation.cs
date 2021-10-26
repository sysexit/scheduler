using Auth.Infrastructure.Requests;

namespace Auth.Infrastructure.Validators
{
    public class LoginRequestValidation : AuthValidation<LoginRequest>
    {
        public LoginRequestValidation()
        {
            ValidateEmailPassword();
        }
    }
}
