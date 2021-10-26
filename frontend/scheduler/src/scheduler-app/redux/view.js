import { createAction, createSlice } from '@reduxjs/toolkit';
import xor from 'lodash/xor';

import { VIEW_TYPE } from 'scheduler-app/lib/constants';

export const UPDATE_TYPE = {
  INCREASE: 'Increase',
  DECREASE: 'Decrease'
};

export const UPDATE_VIEW = 'view/update';
export const updateView = createAction(UPDATE_VIEW, ({ view }) => {
  return {
    payload: {
      view
    }
  };
});

export const UPDATE_DATE = 'view/date';
export const updateDate = createAction(UPDATE_DATE, ({ view, type }) => {
  let count = view == VIEW_TYPE.DAY ? 1 : 7;
  count = type == UPDATE_TYPE.INCREASE ? count : count * -1;
  return {
    payload: {
      count
    }
  };
});

export const SET_DATE = 'view/date/set';
export const setDate = createAction(SET_DATE, ({ date }) => {
  return {
    payload: {
      date
    }
  };
});

export const toggleSidebar = createAction('view/sidebar');

export const TOGGLE_POSITION = 'view/position/toggle';
export const toggleFilterPosition = createAction(
  TOGGLE_POSITION,
  ({ position }) => {
    return {
      payload: {
        position: [position]
      }
    };
  }
);

export const viewSlice = createSlice({
  name: 'view',
  initialState: {
    view: 'Week',
    filteredPositions: [...Array(10).keys()],
    date: new Date(),
    sideBarOpen: false
  },
  reducers: {},
  extraReducers: {
    [updateDate]: (state, { payload }) => {
      const { date } = state;
      const { count } = payload;
      let newDate = new Date(date);

      newDate.setDate(newDate.getDate() + count);
      state.date = newDate;
    },
    [updateView]: (state, { payload }) => {
      state.view = payload.view;
    },
    [toggleFilterPosition]: (state, { payload }) => {
      state.filteredPositions = xor(state.filteredPositions, payload.position);
    },
    [toggleSidebar]: (state, { payload }) => {
      state.sideBarOpen = !state.sideBarOpen;
    },
    [setDate]: (state, { payload }) => {
      state.date = payload.date;
    }
  }
});

export default viewSlice.reducer;
