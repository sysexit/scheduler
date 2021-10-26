import { createSelector } from 'reselect';
import get from 'lodash/get';
import _ from 'lodash/core';

export const getTimesheetOwner = (state) => state.timesheets.user;

export const total = (list, state) =>
  _.reduce(
    list,
    (sum, item) => {
      const user = state.timesheets.user;
      if (item.userid !== user && item.userId !== user) return sum; // FFS

      const start = new Date(item.start);
      const end = new Date(item.end);

      return sum + (end - start) / 1000 / 60 / 60;
    },
    0
  );

export const totalByDay = (list, state) =>
  _.reduce(
    list,
    (result, item) => {
      const user = state.timesheets.user;
      if (item.userid !== user && item.userId !== user) return result; // FFS

      const start = new Date(item.start);
      const end = new Date(item.end);
      const date = start.toDateString();

      const len = (end - start) / 1000 / 60 / 60;
      let value = get(result, date, 0);
      value += len;
      result[date] = value;
      return result;
    },
    {}
  );
