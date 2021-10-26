using Users.Domain.Commands;

namespace Users.Infrastructure.Requests
{
    public class UserStatusRequest : Command
    {
        public string Email { get; set; }
        public bool Enabled { get; set; }

        public UserStatusRequest(string email, bool enabled)
        {
            Email = email;
            Enabled = enabled;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
