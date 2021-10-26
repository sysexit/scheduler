using System;
using Scheduler.Infrastructure.Requests;
using FluentValidation;

namespace Scheduler.Infrastructure.Validators
{
    public class TimesheetValidation<T> : AbstractValidator<T> where T : ScheduleRequest
    {
        protected void ValidateDateTimes()
        {
            //RuleFor(ts => ts.End)
            //    .LessThanOrEqualTo(DateTime.Now)
            //    .WithMessage("Cannot create future timesheets.");
        }
    }
}