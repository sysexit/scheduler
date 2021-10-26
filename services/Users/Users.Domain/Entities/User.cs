using System;

namespace Users.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int[] Positions { get; set; }
        public string Display { get; set; }

        public User(int id, string email, string first, string last, int[] positions, string display)
        {
            Id = id;
            Email = email;
            First = first;
            Last = last;
            Positions = positions;
            Display = display;
        }

        public User(int id, string email)
        {
            Id = id;
            Email = email;
        }

        public User(string email, string first, string last, int[] positions, string display)
        {
            Email = email;
            First = first;
            Last = last;
            Positions = positions;
            Display = display;
        }

        public User(string email, string first, string last, int[] positions) : this(email, first, last, positions, null)
        {
        }
    }
}
