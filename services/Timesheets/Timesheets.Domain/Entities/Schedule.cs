using System;

namespace Timesheets.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; }
        public int UserId { get; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Position { get; }
        public bool Published { get; set; }

        public Schedule(int id, int userId, DateTime start, DateTime end, int position, bool published) : this(id, userId, start, end, position)
        {
            Published = published;
        }

        public Schedule(int id, int userId, DateTime start, DateTime end, int position)
        {
            Id = id;
            UserId = userId;
            Start = start;
            End = end;
            Position = position;
        }

        public Schedule(int userId, DateTime start, DateTime end, int position)
        {
            UserId = userId;
            Start = start;
            End = end;
            Position = position;
        }
    }
}
