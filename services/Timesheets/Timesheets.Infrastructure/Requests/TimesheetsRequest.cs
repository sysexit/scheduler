using System;
using Timesheets.Infrastructure.Validators;

namespace Timesheets.Infrastructure.Requests
{
    public class TimesheetsRequest : TimesheetRequest
    {
        public TimesheetsRequest(int userId, int timesheetId)
        {
            UserId = userId;
            TimesheetId = timesheetId;
        }

        public TimesheetsRequest(int userId, DateTime start, DateTime end, string remoteIPAddress)
        {
            UserId = userId;
            Start = start;
            End = end;
            RemoteIpAddress = remoteIPAddress;
        }
        public TimesheetsRequest(int timesheetId, int userId, DateTime start, DateTime end, string remoteIPAddress) : this(userId, start, end, remoteIPAddress)
        {
            TimesheetId = timesheetId;
        }

        public override bool IsValid()
        {
            ValidationResult = new TimesheetsRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
