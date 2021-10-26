using Timesheets.Application.Interfaces;
using Timesheets.Application.ViewModels;
using Timesheets.Infrastructure.Interfaces;
using Timesheets.Infrastructure.Presenters;
using Timesheets.Infrastructure.Requests;
using Timesheets.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Timesheets.Application.Services
{
    public class TimesheetsService : ITimesheetsService
    {
        private readonly ITimesheetsHandler _timesheetHandler;
        private readonly IAddTimesheetHandler _addTimesheetHandler;
        private readonly IAddDefaultTimesheetHandler _addDefaultTimesheetHandler;
        private readonly IUpdateTimesheetHandler _updateTimesheetHandler;
        private readonly IDeleteTimesheetHandler _deleteTimesheetHandler;
        private readonly TimesheetsPresenter _timesheetsPresenter;
        private readonly TimesheetPresenter _timesheetPresenter;

        public TimesheetsService(ITimesheetsHandler timesheetHandler, IAddTimesheetHandler addTimesheetHandler, IAddDefaultTimesheetHandler addDefaultTimesheetHandler, IUpdateTimesheetHandler updateTimesheetHandler, IDeleteTimesheetHandler deleteTimesheetHandler)
        {
            _timesheetHandler = timesheetHandler;
            _addTimesheetHandler = addTimesheetHandler;
            _addDefaultTimesheetHandler = addDefaultTimesheetHandler;
            _updateTimesheetHandler = updateTimesheetHandler;
            _deleteTimesheetHandler = deleteTimesheetHandler;
            _timesheetsPresenter = new TimesheetsPresenter();
            _timesheetPresenter = new TimesheetPresenter();
        }

        public async Task<TimesheetsResponse> GetTimesheets(GetTimesheetsViewModel model)
        {
            await _timesheetHandler.Handle(new TimesheetsRequest(model.UserId, model.Start, model.End, "request.RemoteIPAddress"), _timesheetsPresenter);
            return _timesheetsPresenter.data;
        }

        public async Task<TimesheetResponse> AddTimesheet(TimesheetsRequest request)
        {
            await _addTimesheetHandler.Handle(request, _timesheetPresenter);
            return _timesheetPresenter.data;
        }

        public async Task<TimesheetsResponse> AddDefaultTimesheet(TimesheetsRequest request)
        {
            await _addDefaultTimesheetHandler.Handle(request, _timesheetsPresenter);
            return _timesheetsPresenter.data;
        }

        public async Task<TimesheetResponse> UpdateTimesheet(TimesheetsRequest request)
        {
            await _updateTimesheetHandler.Handle(request, _timesheetPresenter);
            return _timesheetPresenter.data;
        }

        public async Task DeleteTimesheet(TimesheetsRequest request)
        {
            await _deleteTimesheetHandler.Handle(request);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
