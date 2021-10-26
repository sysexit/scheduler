using Scheduler.Domain.Interfaces;
using Scheduler.Infrastructure.Responses;

namespace Scheduler.Infrastructure.Presenters
{
    public sealed class SchedulePresenter : IOutputPort<ScheduleResponse>
    {
        public ScheduleResponse data { get; set; }

        public void Handle(ScheduleResponse response)
        {
            data = response;
        }
    }
}
