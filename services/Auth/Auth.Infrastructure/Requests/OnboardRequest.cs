using Auth.Infrastructure.Validators;

namespace Auth.Infrastructure.Requests
{
    public class OnboardRequest : AuthRequest
    {
        public OnboardRequest(string display, string email, string first, string last, int[] positions, string remoteIpAddress)
        {
            Display = display;
            Email = email;
            First = first;
            Last = last;
            Positions = positions;
            RemoteIpAddress = remoteIpAddress;
        }

        public OnboardRequest(string email, string first, string last, int[] positions, string remoteIpAddress) : this(null, email, first, last, positions, remoteIpAddress)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new OnboardRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
