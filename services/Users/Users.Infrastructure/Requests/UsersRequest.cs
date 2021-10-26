using System;
using Users.Infrastructure.Validators;

namespace Users.Infrastructure.Requests
{
    public class UsersRequest : UserRequest
    {
        public UsersRequest(int id, string email, string first, string last, int[] positions, string display, bool enabled)
        {
            Id = id;
            Email = email;
            First = first;
            Last = last;
            Positions = positions;
            Display = display;
            Enabled = enabled;
        }

        public UsersRequest(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UsersRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
