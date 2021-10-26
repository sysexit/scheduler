using Scheduler.Application.Interfaces;
using Scheduler.Application.ViewModels;
using Scheduler.Infrastructure.Interfaces;
using Scheduler.Infrastructure.Presenters;
using Scheduler.Infrastructure.Requests;
using Scheduler.Infrastructure.Responses;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Scheduler.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleHandler _scheduleHandler;
        private readonly IPublishScheduleHandler _publishScheduleHandler;
        private readonly IAddScheduleHandler _addScheduleHandler;
        private readonly IUpdateScheduleHandler _updateScheduleHandler;
        private readonly IDeleteScheduleHandler _deleteScheduleHandler;
        private readonly SchedulesPresenter _schedulesPresenter;
        private readonly SchedulePresenter _schedulePresenter;

        public ScheduleService(IScheduleHandler scheduleHandler, IPublishScheduleHandler publishScheduleHandler, IAddScheduleHandler addScheduleHandler, IUpdateScheduleHandler updateScheduleHandler, IDeleteScheduleHandler deleteScheduleHandler)
        {
            _scheduleHandler = scheduleHandler;
            _publishScheduleHandler = publishScheduleHandler;
            _addScheduleHandler = addScheduleHandler;
            _updateScheduleHandler = updateScheduleHandler;
            _deleteScheduleHandler = deleteScheduleHandler;
            _schedulesPresenter = new SchedulesPresenter();
            _schedulePresenter = new SchedulePresenter();
        }

        public async Task<SchedulesResponse> GetSchedule(int groupId, GetScheduleViewModel model)
        {
            await _scheduleHandler.Handle(new SchedulesRequest(groupId, model.Start, model.End), _schedulesPresenter);
            return _schedulesPresenter.data;
        }

        public async Task PublishSchedule(PublishScheduleViewModel model)
        {
            await _publishScheduleHandler.Handle(new SchedulesRequest(model.Start, model.End));
        }

        public async Task<ScheduleResponse> AddSchedule(AddScheduleViewModel model)
        {
            await _addScheduleHandler.Handle(new SchedulesRequest(model.UserId, model.Start, model.End, model.Position, model.RemoteIpAddress), _schedulePresenter);
            return _schedulePresenter.data;
        }

        public async Task<ScheduleResponse> UpdateSchedule(UpdateScheduleViewModel model)
        {
            await _updateScheduleHandler.Handle(new SchedulesRequest(model.Id, model.UserId, model.Start, model.End, model.Position, model.RemoteIpAddress), _schedulePresenter);
            return _schedulePresenter.data;
        }

        public async Task DeleteTimesheet(DeleteScheduleViewModel model)
        {
            await _deleteScheduleHandler.Handle(new SchedulesRequest(model.Id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
