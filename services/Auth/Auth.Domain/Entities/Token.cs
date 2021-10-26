namespace Auth.Domain.Entities
{
    public class Token
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }

        public Token(string email, string accessToken)
        {
            Email = email;
            AccessToken = accessToken;
        }
    }
}
