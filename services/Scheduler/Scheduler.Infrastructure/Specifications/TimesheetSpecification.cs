using Scheduler.Domain.Entities;

namespace Scheduler.Infrastructure.Specifications
{
    class TimesheetSpecification : BaseSpecification<Schedule>
    {
        public TimesheetSpecification(int userId) : base(u => u.UserId == userId)
        {
            AddInclude(u => u.UserId);
        }
    }
}
