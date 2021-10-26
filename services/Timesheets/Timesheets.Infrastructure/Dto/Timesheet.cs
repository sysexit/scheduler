using System;

namespace Timesheets.Infrastructure.Dto
{
    public sealed class Timesheet
    {
        public int Id { get; }
        public int UserId { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public Timesheet(int id, int userId, DateTime start, DateTime end)
        {
            Id = id;
            UserId = userId;
            Start = start;
            End = end;
        }
    }
}
