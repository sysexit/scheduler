using Timesheets.Infrastructure.Dto;

namespace Timesheets.Infrastructure.Responses
{
    public class TimesheetResponse
    {
        public Timesheet Timesheet { get; }

        public TimesheetResponse(Domain.Entities.Timesheet timesheet)
        {
            Timesheet = new Timesheet(timesheet.Id, timesheet.UserId, timesheet.Start, timesheet.End);
        }
    }
}
