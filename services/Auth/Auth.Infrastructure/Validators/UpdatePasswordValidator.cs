using Auth.Infrastructure.Requests;

namespace Auth.Infrastructure.Validators
{
    public class UpdatePasswordValidator : AuthValidation<UpdatePasswordRequest>
    {
        public UpdatePasswordValidator()
        {
            ValidatePasswordsMatch();
        }
    }
}
