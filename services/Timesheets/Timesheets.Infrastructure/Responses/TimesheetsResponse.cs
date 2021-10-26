using Timesheets.Infrastructure.Dto;
using System.Collections.Generic;
using System;

namespace Timesheets.Infrastructure.Responses
{
    public class TimesheetsResponse
    {
        public List<Timesheet> Timesheets { get; }

        public TimesheetsResponse(List<Timesheet> timesheets)
        {
            Timesheets = timesheets;
        }

        public TimesheetsResponse(List<Domain.Entities.Timesheet> timesheets)
        {
            List<Timesheet> timesheetsList = new List<Timesheet>();
            foreach (Domain.Entities.Timesheet ts in timesheets) {
                var times = new Timesheet(ts.Id, ts.UserId, ts.Start, ts.End);
                timesheetsList.Add(times);
            }
            Timesheets = timesheetsList;
        }

        public TimesheetsResponse(Domain.Entities.Timesheet timesheet)
        {
            List<Timesheet> timesheetsList = new List<Timesheet>();
            var sheet = new Timesheet(timesheet.Id, timesheet.UserId, timesheet.Start, timesheet.End);
            timesheetsList.Add(sheet);
            Timesheets = timesheetsList;
        }
    }
}
