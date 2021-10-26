using Timesheets.Application.ViewModels;
using Timesheets.Infrastructure.Responses;
using System;
using System.Threading.Tasks;
using Timesheets.Infrastructure.Requests;

namespace Timesheets.Application.Interfaces
{
    public interface ITimesheetsService : IDisposable
    {
        Task<TimesheetsResponse> GetTimesheets(GetTimesheetsViewModel model);
        Task<TimesheetResponse> AddTimesheet(TimesheetsRequest request);
        Task<TimesheetsResponse> AddDefaultTimesheet(TimesheetsRequest request);
        Task<TimesheetResponse> UpdateTimesheet(TimesheetsRequest request);
        Task DeleteTimesheet(TimesheetsRequest request);
    }
}
