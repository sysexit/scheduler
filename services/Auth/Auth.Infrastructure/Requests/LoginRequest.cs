using Auth.Infrastructure.Validators;

namespace Auth.Infrastructure.Requests
{
    public class LoginRequest : AuthRequest
    {
        public LoginRequest()
        {
        }

        public LoginRequest(string email, string password, string remoteIpAddress)
        {
            Email = email;
            Password = password;
            RemoteIpAddress = remoteIpAddress;
        }

        public override bool IsValid()
        {
            ValidationResult = new LoginRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
