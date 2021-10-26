using Auth.Infrastructure.Requests;

namespace Auth.Infrastructure.Validators
{
    public class ForgotPasswordRequestValidation : AuthValidation<ForgotPasswordRequest>
    {
        public ForgotPasswordRequestValidation()
        {
            ValidateEmail();
        }
    }
}
