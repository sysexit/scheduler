using Positions.Infrastructure.Requests;

namespace Positions.Infrastructure.Validators
{
    public class PositionsRequestValidation : PositionValidation<PositionsRequest>
    {
        public PositionsRequestValidation()
        {
            ValidateDateTimes();
        }
    }
}
