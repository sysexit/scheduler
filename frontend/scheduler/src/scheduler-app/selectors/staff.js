import { createSelector } from 'reselect';
import { getEnabledPositions } from './positions';

const getStaff = (state) => state.staff;

export const scheduleUsersSelector = createSelector(getStaff, (staff) =>
  staff
);

export const getScheduleViewStaff = createSelector(
  [scheduleUsersSelector, getEnabledPositions],
  (staff, positions) =>
    staff.filter((u) => positions.some((p) => u.positions != null && u.positions.includes(p)))
);
