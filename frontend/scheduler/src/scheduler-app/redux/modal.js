import { createAction, createSlice } from '@reduxjs/toolkit';

const initialState = {
  modalType: null,
  modalProps: {
    open: false
  }
};

export const SHOW_MODAL = 'modal/show';
export const showModal = createAction(
  SHOW_MODAL,
  ({ modalProps, modalType }) => {
    return {
      payload: {
        modalProps,
        modalType
      }
    };
  }
);

export const hideModal = createAction('modal/hide');

export const modalSlice = createSlice({
  name: 'modal',
  initialState,
  reducers: {},
  extraReducers: {
    [showModal]: (state, { payload }) => payload,
    [hideModal]: (state, { payload }) => initialState
  }
});

export default modalSlice.reducer;
