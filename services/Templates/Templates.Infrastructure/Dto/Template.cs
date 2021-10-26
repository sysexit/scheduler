namespace Templates.Infrastructure.Dto
{
    public sealed class Template
    {
        public int Id { get; }
        public string Start { get; }
        public string End { get; }
        public int Position { get; set; }

        public Template(int id, string start, string end, int position)
        {
            Id = id;
            Start = start;
            End = end;
            Position = position;
        }
    }
}
