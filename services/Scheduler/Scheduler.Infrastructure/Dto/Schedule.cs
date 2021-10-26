using NodaTime;
using System;

namespace Scheduler.Infrastructure.Dto
{
    public sealed class Schedule
    {
        public int Id { get; }
        public int Userid { get; } // Userid not UserId for frontend compat...
        public Instant Start { get; }
        public Instant End { get; }
        public int Position { get; }
        public bool Published { get; }

        public Schedule(int id, int userId, Instant start, Instant end, int position, bool published)
        {
            Id = id;
            Userid = userId;
            Start = start;
            End = end;
            Position = position;
            Published = published;
        }
    }
}
