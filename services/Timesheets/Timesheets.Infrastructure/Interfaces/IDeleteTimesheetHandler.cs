using Timesheets.Infrastructure.Requests;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Interfaces
{
    public interface IDeleteTimesheetHandler
    {
        Task Handle(TimesheetsRequest message);
    }
}
