using Users.Domain.Commands;

namespace Users.Infrastructure.Requests
{
    public abstract class UserRequest : Command
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int[] Positions { get; set; }
        public string Display { get; set; }
        public bool Enabled { get; set; }
    }
}
