using System;

namespace Templates.Domain.Entities
{
    public class Template
    {
        public int Id { get; }
        public string Start { get; }
        public string End { get; }
        public int Position { get; }

        public Template(int id, string start, string end, int position)
        {
            Id = id;
            Start = start;
            End = end;
            Position = position;
        }

        public Template(string start, string end, int position)
        {
            Start = start;
            End = end;
            Position = position;
        }
    }
}
