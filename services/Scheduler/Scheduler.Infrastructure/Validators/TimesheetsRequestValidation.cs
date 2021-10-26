using Scheduler.Infrastructure.Requests;

namespace Scheduler.Infrastructure.Validators
{
    public class TimesheetsRequestValidation : TimesheetValidation<SchedulesRequest>
    {
        public TimesheetsRequestValidation()
        {
            ValidateDateTimes();
        }
    }
}
