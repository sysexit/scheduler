using System;
using Timesheets.Domain.Commands;

namespace Timesheets.Infrastructure.Requests
{
    public abstract class TimesheetRequest : Command
    {
        public int TimesheetId { get; set; }
        public int UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string RemoteIpAddress { get; set; }
    }
}
