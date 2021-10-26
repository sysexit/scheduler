import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { ScheduleAPI } from '../services';
import {
  getViewEnd,
  getViewStart,
  getWeekEnd,
  getWeekStart
} from './selectors';

export const LOAD_SCHEDULE = 'schedule/load';
export const loadSchedule = createAsyncThunk(
  LOAD_SCHEDULE,
  async ({ start, end }) => {
    const response = await ScheduleAPI.get({ start, end });
    const { schedule } = response.data || [];

    return {
      schedule
    };
  }
);

export const ADD_SCHEDULE = 'schedule/add';
export const addSchedule = createAsyncThunk(
  ADD_SCHEDULE,
  async ({ shift }, { dispatch, getState }) => {
    const start = getViewStart(getState());
    const end = getViewEnd(getState());

    await ScheduleAPI.create(shift);
    dispatch(loadSchedule({ start, end }));
  }
);

export const UPDATE_SCHEDULE = 'schedule/update';
export const updateSchedule = createAsyncThunk(
  UPDATE_SCHEDULE,
  async ({ shift }, { dispatch, getState }) => {
    const start = getViewStart(getState());
    const end = getViewEnd(getState());

    await ScheduleAPI.update(shift);
    dispatch(loadSchedule({ start, end }));
  }
);

export const DELETE_SCHEDULE = 'schedule/delete';
export const deleteSchedule = createAsyncThunk(
  DELETE_SCHEDULE,
  async ({ id }, { dispatch, getState }) => {
    const start = getViewStart(getState());
    const end = getViewEnd(getState());

    await ScheduleAPI.delete({ id });
    dispatch(loadSchedule({ start, end }));
  }
);

export const PUBLISH_SCHEDULE = 'schedule/publish';
export const publishSchedule = createAsyncThunk(
  PUBLISH_SCHEDULE,
  async (_, { dispatch, getState }) => {
    const state = getState();
    const start = getViewStart(state);
    const end = getViewEnd(state);
    const weekStart = getWeekStart(state);
    const weekEnd = getWeekEnd(state);

    await ScheduleAPI.publish({ start, end });
    dispatch(loadSchedule({ start: weekStart, end: weekEnd }));
  }
);

export const scheduleSlice = createSlice({
  name: 'schedule',
  initialState: [],
  reducers: {},
  extraReducers: {
    [loadSchedule.fulfilled]: (state, { payload }) => (state = payload.schedule)
    // [addSchedule.fulfilled]: (state, { payload }) => state = payload.schedule,
    // [updateSchedule.fulfilled]: (state, { payload }) => state = payload.schedule,
    // [deleteSchedule.fulfilled]: (state, { payload }) => state = payload.schedule,
    // [publishSchedule.fulfilled]: (state, { payload }) => state = payload.schedule,
  }
});

export default scheduleSlice.reducer;
