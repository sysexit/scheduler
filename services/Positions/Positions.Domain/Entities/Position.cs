namespace Positions.Domain.Entities
{
    public class Position
    {
        public int Id { get; }
        public string Title { get; }

        public Position(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public Position(string title)
        {
            Title = title;
        }
    }
}
