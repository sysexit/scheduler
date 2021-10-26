import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { SessionAPI } from '../services';
// import { push } from "connected-react-router";

export const LOGIN = 'scheduler/auth/login';
export const login = createAsyncThunk(
  LOGIN,
  async (credentials, { dispatch, getState }) => {
    const response = await SessionAPI.create(credentials);

    if (response.status == 200) {
      // dispatch(push("/"));
      window.location = '/';
    }
  }
);

export const authSlice = createSlice({
  name: 'auth',
  initialState: {
    user: null
  },
  reducers: {},
  extraReducers: {
    // [login.fulfilled]: (state, action) => state.user = action.payload.user,
  }
});

export default authSlice.reducer;
