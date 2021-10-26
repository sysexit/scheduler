using Auth.Infrastructure.Requests;
using FluentValidation;

namespace Auth.Infrastructure.Validators
{
    public class AuthValidation<T> : AbstractValidator<T> where T : AuthRequest
    {
        protected void ValidateExchangeRefreshToken()
        {
            RuleFor(x => x.AccessToken).NotEmpty().WithMessage("An access token is required");
            //RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("A refresh token is required");
        }

        protected void ValidateEmailPassword()
        {
            RuleFor(x => x.Email).NotEmpty().Length(3, 255);
            RuleFor(x => x.Password).NotEmpty().Length(6, 255);
        }

        protected void ValidatePasswordsMatch()
        {
            RuleFor(x => x.Password).NotEmpty().Length(6, 255);
            RuleFor(x => x.Password)
                .Equal(x => x.PasswordConfirm)
                .WithMessage("Passwords do not match.");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Email address is required.")
                .EmailAddress()
                .WithMessage("A valid email address is required."); ;
        }
    }
}