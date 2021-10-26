import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import _ from 'lodash/core';
import { PositionsAPI } from '../services';

export const LOAD_POSITIONS = 'positions/load';
export const loadPositions = createAsyncThunk(LOAD_POSITIONS, async () => {
  const response = await PositionsAPI.get();
  const { positions } = response.data;
  return {
    positions
  };
});

export const positionsSlice = createSlice({
  name: 'positions',
  initialState: [],
  reducers: {},
  extraReducers: {
    [loadPositions.fulfilled]: (state, { payload }) =>
      (state = payload.positions)
  }
});

export default positionsSlice.reducer;
