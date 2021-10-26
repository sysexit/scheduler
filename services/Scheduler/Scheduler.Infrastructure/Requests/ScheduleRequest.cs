using System;
using NodaTime;
using Scheduler.Domain.Commands;

namespace Scheduler.Infrastructure.Requests
{
    public abstract class ScheduleRequest : Command
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public Instant Start { get; set; }
        public Instant End { get; set; }
        public int Position { get; set; }
        public bool Published { get; set; }
        public string RemoteIpAddress { get; set; }
    }
}
