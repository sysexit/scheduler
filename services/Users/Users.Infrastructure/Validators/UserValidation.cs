using System;
using Users.Infrastructure.Requests;
using FluentValidation;

namespace Users.Infrastructure.Validators
{
    public class UserValidation<T> : AbstractValidator<T> where T : UserRequest
    {
        protected void ValidateDateTimes()
        {
            //RuleFor(ts => ts.End)
            //    .LessThanOrEqualTo(DateTime.Now)
            //    .WithMessage("Cannot create future timesheets.");
        }
    }
}