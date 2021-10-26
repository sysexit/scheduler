using Auth.Domain.Commands;

namespace Auth.Infrastructure.Requests
{
    public abstract class AuthRequest : Command
    {
        public int Id { get; set; }
        public string Display { get; set; }
        public string Email { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int[] Positions { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Token { get; set; }
        public string RemoteIpAddress { get; set; }
        public object AccessToken { get; internal set; }
    }
}
