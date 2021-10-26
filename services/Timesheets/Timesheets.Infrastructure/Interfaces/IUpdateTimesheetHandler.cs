using Timesheets.Infrastructure.Requests;
using System.Threading.Tasks;
using Timesheets.Infrastructure.Responses;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Infrastructure.Interfaces
{
    public interface IUpdateTimesheetHandler
    {
        Task Handle(TimesheetsRequest message, IOutputPort<TimesheetResponse> outputPort);
    }
}
