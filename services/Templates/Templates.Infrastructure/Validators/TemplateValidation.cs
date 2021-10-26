using System;
using Templates.Infrastructure.Requests;
using FluentValidation;

namespace Templates.Infrastructure.Validators
{
    public class TemplateValidation<T> : AbstractValidator<T> where T : TemplateRequest
    {
        protected void ValidateDateTimes()
        {
            //RuleFor(ts => ts.End)
            //    .LessThanOrEqualTo(DateTime.Now)
            //    .WithMessage("Cannot create future timesheets.");
        }
    }
}