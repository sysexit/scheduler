namespace Positions.Infrastructure.Dto
{
    public sealed class Position
    {
        public int Id { get; }
        public string Title { get; }

        public Position(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
