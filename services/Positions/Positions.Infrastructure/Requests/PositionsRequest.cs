using System;
using Positions.Infrastructure.Validators;

namespace Positions.Infrastructure.Requests
{
    public class PositionsRequest : PositionRequest
    {
        public PositionsRequest()
        {
        }

        public PositionsRequest(int id)
        {
            Id = id;
        }

        public PositionsRequest(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public PositionsRequest(string title)
        {
            Title = title;
        }

        public override bool IsValid()
        {
            ValidationResult = new PositionsRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
