using Auth.Infrastructure.Requests;

namespace Auth.Infrastructure.Validators
{
    public class OnboardRequestValidation : AuthValidation<OnboardRequest>
    {
        public OnboardRequestValidation()
        {
            ValidateEmail();
        }
    }
}
