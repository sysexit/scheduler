namespace Templates.Infrastructure.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Group = "group", Id = "id";
            }

            public static class JwtClaims
            {
                public const string Admin = "0";
                public const string Staff = "1";
            }
        }
    }
}
