using Auth.Infrastructure.Validators;

namespace Auth.Infrastructure.Requests
{
    public class UpdatePasswordRequest : AuthRequest
    {
        public UpdatePasswordRequest(int id, string currentPassword, string password, string passwordConfirm)
        {
            Id = id;
            CurrentPassword = currentPassword;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePasswordValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
