import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { UserAPI } from '../services';

export const LOAD_CURRENT_USER = 'scheduler/users/load/current';
export const loadCurrentUser = createAsyncThunk(LOAD_CURRENT_USER, async () => {
  const response = await UserAPI.get_current();
  const user = response.data;

  return {
    user
  };
});

export const currentUserSlice = createSlice({
  name: 'currentUser',
  initialState: {},
  reducers: {},
  extraReducers: {
    [loadCurrentUser.fulfilled]: (state, { payload }) => (state = payload.user)
  }
});

export default currentUserSlice.reducer;
