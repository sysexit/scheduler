using Auth.Infrastructure.Validators;

namespace Auth.Infrastructure.Requests
{
    public class ResetPasswordRequest : AuthRequest
    {
        public ResetPasswordRequest(string email, string password, string passwordConfirm, string token, string remoteIpAddress)
        {
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
            Token = token;
            RemoteIpAddress = remoteIpAddress;
        }

        public override bool IsValid()
        {
            ValidationResult = new ResetPasswordRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
