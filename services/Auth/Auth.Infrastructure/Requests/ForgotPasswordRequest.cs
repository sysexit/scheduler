using Auth.Infrastructure.Validators;

namespace Auth.Infrastructure.Requests
{
    public class ForgotPasswordRequest : AuthRequest
    {
        public ForgotPasswordRequest(string email, string remoteIpAddress)
        {
            Email = email;
            RemoteIpAddress = remoteIpAddress;
        }

        public override bool IsValid()
        {
            ValidationResult = new ForgotPasswordRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
