using Timesheets.Domain.Entities;

namespace Timesheets.Infrastructure.Specifications
{
    class TimesheetSpecification : BaseSpecification<Timesheet>
    {
        public TimesheetSpecification(int userId) : base(u => u.UserId == userId)
        {
            AddInclude(u => u.UserId);
        }
    }
}
