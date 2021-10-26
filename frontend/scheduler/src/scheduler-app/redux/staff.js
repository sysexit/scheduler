import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import _ from 'lodash/core';

import { UserAPI } from 'scheduler-app/services';

export const LOAD_STAFF = 'staff/load';
export const loadStaff = createAsyncThunk(LOAD_STAFF, async ({ type }) => {
  const response = await UserAPI.get({ type });
  const { users } = response.data;

  return {
    users
  };
});

export const ADD_STAFF = 'staff/add';
export const addStaff = createAsyncThunk(ADD_STAFF, async ({ user }) => {
  const response = await UserAPI.onboard(user); // TODO: Load staff after onboard
  const { users } = response.data;

  return {
    users
  };
});

export const DISABLE_STAFF = 'staff/disable';
export const disableStaff = createAsyncThunk(DISABLE_STAFF, async ({ id }) => {
  await UserAPI.delete({ id });
  return id;
});

export const staffSlice = createSlice({
  name: 'staff',
  initialState: [],
  reducers: {},
  extraReducers: {
    [loadStaff.fulfilled]: (state, { payload }) => (state = payload.users),
    [addStaff.fulfilled]: (state, { payload }) => (state = payload.staff),
    [disableStaff.fulfilled]: (state, { payload }) =>
      (state = _.remove(state, (p) => p.id == payload.id))
  }
});

export default staffSlice.reducer;
