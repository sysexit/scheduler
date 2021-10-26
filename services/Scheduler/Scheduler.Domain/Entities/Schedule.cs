using NodaTime;
using System;

namespace Scheduler.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; }
        public int UserId { get; }
        public Instant Start { get; set; }
        public Instant End { get; set; }
        public int Position { get; }
        public bool Published { get; set; }

        public Schedule(int id, int userId, Instant start, Instant end, int position, bool published) : this(id, userId, start, end, position)
        {
            Published = published;
        }

        public Schedule(int id, int userId, Instant start, Instant end, int position)
        {
            Id = id;
            UserId = userId;
            Start = start;
            End = end;
            Position = position;
        }

        public Schedule(int userId, Instant start, Instant end, int position)
        {
            UserId = userId;
            Start = start;
            End = end;
            Position = position;
        }
    }
}
