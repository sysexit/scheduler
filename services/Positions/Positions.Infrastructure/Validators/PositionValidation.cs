using System;
using Positions.Infrastructure.Requests;
using FluentValidation;

namespace Positions.Infrastructure.Validators
{
    public class PositionValidation<T> : AbstractValidator<T> where T : PositionRequest
    {
        protected void ValidateDateTimes()
        {
            //RuleFor(ts => ts.End)
            //    .LessThanOrEqualTo(DateTime.Now)
            //    .WithMessage("Cannot create future timesheets.");
        }
    }
}