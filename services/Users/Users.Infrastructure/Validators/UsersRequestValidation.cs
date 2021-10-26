using Users.Infrastructure.Requests;

namespace Users.Infrastructure.Validators
{
    public class UsersRequestValidation : UserValidation<UsersRequest>
    {
        public UsersRequestValidation()
        {
            ValidateDateTimes();
        }
    }
}
