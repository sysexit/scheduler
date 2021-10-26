using System;
using Timesheets.Infrastructure.Requests;
using FluentValidation;

namespace Timesheets.Infrastructure.Validators
{
    public class TimesheetValidation<T> : AbstractValidator<T> where T : TimesheetRequest
    {
        protected void ValidateDateTimes()
        {
            //RuleFor(ts => ts.End)
            //    .LessThanOrEqualTo(DateTime.Now)
            //    .WithMessage("Cannot create future timesheets.");
        }
    }
}