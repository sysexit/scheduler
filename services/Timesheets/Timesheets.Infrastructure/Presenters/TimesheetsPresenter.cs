using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Responses;

namespace Timesheets.Infrastructure.Presenters
{
    public sealed class TimesheetsPresenter : IOutputPort<TimesheetsResponse>
    {
        public TimesheetsResponse data { get; set; }

        public void Handle(TimesheetsResponse response)
        {
            data = response;
        }
    }
}
