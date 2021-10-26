using Timesheets.Infrastructure.Requests;

namespace Timesheets.Infrastructure.Validators
{
    public class TimesheetsRequestValidation : TimesheetValidation<TimesheetsRequest>
    {
        public TimesheetsRequestValidation()
        {
            ValidateDateTimes();
        }
    }
}
