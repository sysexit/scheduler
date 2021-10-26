import { createAction, createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { TimesheetsAPI } from '../services';
import _ from 'lodash/core';
import remove from 'lodash/remove';
import concat from 'lodash/concat';

export const LOAD_TIMESHEETS = 'timesheets/load';
export const loadTimesheets = createAsyncThunk(
  LOAD_TIMESHEETS,
  async ({ user_id, start }) => {
    const response = await TimesheetsAPI.get({ user_id }, { start });
    const { timesheets } = response.data.data || [];

    return {
      timesheets
    };
  }
);

export const SET_TIMESHEET_USER = 'timesheets/user/set';
export const setTimesheetUser = createAction(SET_TIMESHEET_USER, ({ user }) => {
  return {
    payload: {
      user
    }
  };
});

export const SUBMIT_TIMESHEET = 'timesheets/submit';
export const submitTimesheet = createAsyncThunk(
  SUBMIT_TIMESHEET,
  async ({ user_id, timesheet }) => {
    const response = await TimesheetsAPI.create({ user_id }, timesheet);
    const _timesheet = response.data.data.timesheet;

    return {
      timesheet: _timesheet
    };
  }
);

export const SUBMIT_DEFAULT = 'timesheets/default';
export const submitDefault = createAsyncThunk(
  SUBMIT_DEFAULT,
  async ({ user_id, start, end }) => {
    const response = await TimesheetsAPI.default({ user_id }, { start, end });
    const { timesheets } = response.data.data || [];

    return {
      timesheets
    };
  }
);

export const UPDATE_TIMESHEET = 'timesheets/update';
export const updateTimesheet = createAsyncThunk(
  UPDATE_TIMESHEET,
  async ({ user_id, id, timesheet }) => {
    const response = await TimesheetsAPI.update({ user_id, id }, timesheet);
    const _timesheet = response.data.data.timesheet;

    return {
      timesheet: _timesheet
    };
  }
);

export const DELETE_TIMESHEET = 'timesheets/delete';
export const deleteTimesheet = createAsyncThunk(
  DELETE_TIMESHEET,
  async ({ user_id, id }) => {
    await TimesheetsAPI.delete({ user_id, id });
    return {
      id
    };
  }
);

export const timesheetsSlice = createSlice({
  name: 'timesheets',
  initialState: {
    user: null,
    timesheets: null
  },
  reducers: {},
  extraReducers: {
    [loadTimesheets.fulfilled]: (state, { payload }) => {
      state.timesheets = payload.timesheets;
    },
    [setTimesheetUser]: (state, { payload }) => {
      state.user = payload.user;
    },
    [submitTimesheet.fulfilled]: (state, { payload }) => {
      state.timesheets = state.timesheets
        ? [...state.timesheets, payload.timesheet]
        : [payload.timesheet];
    },
    [updateTimesheet.fulfilled]: (state, { payload }) => {
      let timesheets = remove(
        state.timesheets,
        (t) => t.id !== payload.timesheet.id
      );
      state.timesheets = concat(timesheets, payload.timesheet);
    },
    [deleteTimesheet.fulfilled]: (state, { payload }) => {
      state.timesheets = remove(state.timesheets, (t) => t.id !== payload.id);
    },
    [submitDefault.fulfilled]: (state, { payload }) => {
      state.timesheets = payload.timesheets;
    },
  }
});

export default timesheetsSlice.reducer;
