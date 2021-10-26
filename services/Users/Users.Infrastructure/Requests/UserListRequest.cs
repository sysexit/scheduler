using Users.Domain.Commands;

namespace Users.Infrastructure.Requests
{
    public class UserListRequest : Command
    {
        public UserRequestType Type { get; set; }

        public UserListRequest(UserRequestType type)
        {
            Type = type;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
