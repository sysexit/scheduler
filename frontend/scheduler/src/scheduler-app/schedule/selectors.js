import { createSelector } from 'reselect';
import _ from 'lodash/core';

import { VIEW_TYPE } from 'scheduler-app/lib/constants';
import { startOf, endOf } from 'scheduler-app/lib/time';
import {
  getTimesheetOwner
} from '../timesheets/selectors';
import { getMonday, getSunday } from '../utils/helpers';
import { getEnabledPositions } from '../selectors/positions';

export const getView = (state) => state.view.view;

export const getWeekEnd = (state) => getSunday(state.view.date);

export const getDate = (state) => state.view.date;

export const getWeekStart = (state) => getMonday(state.view.date);

export const getSchedule = (state) => state.schedule;

export const getActiveSchedule = (state) => {
  const view = state.view.view;
  if (view == VIEW_TYPE.DAY) return scheduleByDay(state);
  if (view == VIEW_TYPE.WEEK) return scheduleByWeek(state);
};

export const getUserSchedule = createSelector(
  [getSchedule, getTimesheetOwner, getWeekStart, getWeekEnd],
  (schedule, user, start, end) => {
    if (schedule == [] || !user) return [];

    return _.filter(schedule, (s) => {
      const shiftStart = new Date(s.start);
      const shiftEnd = new Date(s.end);
      if (s.userid !== user) return false;

      return shiftStart >= start && shiftEnd <= end;
    });
  }
);

export const getViewStart = createSelector(
  [getView, getDate, getWeekStart],
  (view, date, weekStart) => {
    if (view == VIEW_TYPE.DAY) {
      return startOf(date);
    } else {
      return weekStart;
    }
  }
);

export const getViewEnd = createSelector(
  [getView, getDate, getWeekEnd],
  (view, date, weekEnd) => {
    if (view == VIEW_TYPE.DAY) {
      return endOf(date);
    } else {
      return weekEnd;
    }
  }
);

export const getFilteredSchedule = createSelector(
  [getSchedule, getEnabledPositions, getViewStart, getView],
  (schedule, positions, start, view) => {
    return _.filter(schedule, (s) => {
      if (!positions.includes(s.position)) return false;
      const vStart = start.toDateString();
      if (view == VIEW_TYPE.DAY) {
        return new Date(s.start).toDateString() == vStart;
      }
      return true;
    });
  }
);

export const scheduleByWeek = createSelector(
  [getFilteredSchedule],
  (schedule) => {
    return _.reduce(
      schedule,
      (result, item) => {
        const start = new Date(item.start);
        const end = new Date(item.end);
        const date = start.toDateString();
        const length = (end - start) / 1000 / 60 / 60;

        const modifiedShift = {
          ...item,
          length
        };

        (result[date] || (result[date] = [])).push(modifiedShift);
        return result;
      },
      {}
    );
  }
);

export const scheduleByDay = createSelector(
  [getFilteredSchedule],
  (schedule) => {
    return _.reduce(
      schedule,
      (result, item) => {
        const itemStart = new Date(item.start);
        const hour = itemStart.getHours();
        (result[hour] || (result[hour] = [])).push(item);
        return result;
      },
      {}
    );
  }
);
