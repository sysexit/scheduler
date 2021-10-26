using Auth.Infrastructure.Requests;

namespace Auth.Infrastructure.Validators
{
    public class ResetPasswordRequestValidation : AuthValidation<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidation()
        {
            ValidateEmail();
            ValidatePasswordsMatch();
        }
    }
}
