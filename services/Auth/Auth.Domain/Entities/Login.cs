namespace Auth.Domain.Entities
{
    public class Login
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Group { get; set; }
        public bool Enabled { get; set; }

        public Login(string email, string password, int group, bool enabled)
        {
            Email = email;
            PasswordHash = password;
            Group = group;
            Enabled = enabled;
        }

        public Login(string email)
        {
            Email = email;
        }
    }
}
