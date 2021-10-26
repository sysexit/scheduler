using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Requests;
using Timesheets.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Interfaces
{
    public interface ITimesheetsHandler
    {
        Task Handle(TimesheetsRequest message, IOutputPort<TimesheetsResponse> outputPort);
    }
}
