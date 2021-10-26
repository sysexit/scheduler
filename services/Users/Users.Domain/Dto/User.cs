namespace Users.Domain.Dto
{
    public class User
    {
        public int Id { get; }
        public string Email { get;  }
        public string First { get;  }
        public string Last { get;  }
        public int[] Positions { get;}
        public string Display { get; }
        public int Group { get; }
        public bool Enabled { get; }

        public User(int id, string email, string first, string last, int[] positions, string display)
        {
            Id = id;
            Email = email;
            First = first;
            Last = last;
            Positions = positions;
            Display = display;
        }

        public User(int id, string email, string first, string last, int[] positions, string display, int group, bool enabled) : this(id, email, first, last, positions, display)
        {
            Group = group;
            Enabled = enabled;
        }
    }
}
