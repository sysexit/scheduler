import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { loadCurrentUser } from '../redux/user';
import { UserAPI } from '../services';

export const UPDATE_USER_DETAILS = 'scheduler/users/update/details';
export const updateUserDetails = createAsyncThunk(
  UPDATE_USER_DETAILS,
  async ({ user }, { dispatch, getState }) => {
    await UserAPI.update(user);

    dispatch(loadCurrentUser());

    return {
      success: true
    };
  }
);

export const UPDATE_USER_PASSWORD = 'scheduler/users/update/password';
export const updateUserPassword = createAsyncThunk(
  UPDATE_USER_PASSWORD,
  async ({ password, new_password, confirm_password }, { dispatch, getState }) => {
    await UserAPI.update_password({ currentpassword: password, newpassword: new_password, newpasswordconfirm: confirm_password });

    dispatch(loadCurrentUser());

    return {
      success: true
    };
  }
);

export const usersSlice = createSlice({
  name: 'user',
  initialState: {
    tab: 'password'
  },
  reducers: {},
  extraReducers: {
    [updateUserDetails.fulfilled]: (state, { payload }) =>
      (state = payload.user),
    [updateUserPassword.fulfilled]: (state, { payload }) =>
      (state = payload.user)
  }
});

export default usersSlice.reducer;
