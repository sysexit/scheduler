import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import _ from 'lodash/core';

import { UserAPI } from 'scheduler-app/services';
import { loadStaff } from 'scheduler-app/redux/staff';
import { LOAD_STAFF_TYPE } from 'scheduler-app/lib/constants';

export const UPDATE_PERSON = 'people/update';
export const updatePerson = createAsyncThunk(
  UPDATE_PERSON,
  async ({ user }, { dispatch, getState }) => {
    await UserAPI.update(user);
    dispatch(loadStaff());
  }
);

export const ADD_PERSON = 'people/add';
export const addPerson = createAsyncThunk(
  ADD_PERSON,
  async ({ user }, { dispatch, getState }) => {
    await UserAPI.onboard(user);
    dispatch(loadStaff(LOAD_STAFF_TYPE.ALL));
  }
);

export const DISABLE_PERSON = 'people/disable';
export const disablePerson = createAsyncThunk(
  DISABLE_PERSON,
  async ({ email }, { dispatch, getState }) => {
    await UserAPI.status({ email, enabled: false });
    dispatch(loadStaff());
  }
);

export const ENABLE_PERSON = 'people/disable';
export const enablePerson = createAsyncThunk(
  ENABLE_PERSON,
  async ({ email }, { dispatch, getState }) => {
    await UserAPI.status({ email, enabled: true });
    dispatch(loadStaff());
  }
);

export const peopleSlice = createSlice({
  name: 'people',
  initialState: [],
  reducers: {},
  extraReducers: {
    [addPerson.fulfilled]: (state, { payload }) => (state = payload.people)
  }
});

export default peopleSlice.reducer;
