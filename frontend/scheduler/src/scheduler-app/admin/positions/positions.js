import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

import { PositionsAPI } from 'scheduler-app/services';
import { loadPositions } from '../../redux/positions';

export const ADD_POSITION = 'position/add';
export const addPosition = createAsyncThunk(
  ADD_POSITION,
  async ({ position }, { dispatch, getState }) => {
    await PositionsAPI.create(position);
    dispatch(loadPositions());
  }
);

export const ENABLE_POSITION = 'position/enable';
export const enablePosition = createAsyncThunk(
  ENABLE_POSITION,
  async ({ positionid }, { dispatch, getState }) => {
    await PositionsAPI.update({ positionid });
    dispatch(loadPositions());
  }
);

export const DISABLE_POSITION = 'position/disable';
export const disablePosition = createAsyncThunk(
  DISABLE_POSITION,
  async ({ positionid }, { dispatch, getState }) => {
    await PositionsAPI.delete({ positionid });
    dispatch(loadPositions());
  }
);

export const adminPositionsSlice = createSlice({
  name: 'adminPositions',
  initialState: [],
  reducers: {},
  extraReducers: {}
});

export default adminPositionsSlice.reducer;
