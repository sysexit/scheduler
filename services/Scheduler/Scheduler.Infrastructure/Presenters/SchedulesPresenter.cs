using Scheduler.Domain.Interfaces;
using Scheduler.Infrastructure.Responses;

namespace Scheduler.Infrastructure.Presenters
{
    public sealed class SchedulesPresenter : IOutputPort<SchedulesResponse>
    {
        public SchedulesResponse data { get; set; }

        public void Handle(SchedulesResponse response)
        {
            data = response;
        }
    }
}
