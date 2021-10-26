using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Responses;

namespace Timesheets.Infrastructure.Presenters
{
    public sealed class TimesheetPresenter : IOutputPort<TimesheetResponse>
    {
        public TimesheetResponse data { get; set; }

        public void Handle(TimesheetResponse response)
        {
            data = response;
        }
    }
}
