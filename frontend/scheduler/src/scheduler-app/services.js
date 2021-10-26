import { DELETE, GET, POST, PUT } from 'scheduler-app/lib/api';
import { GETNEW, POSTNEW, PUTNEW, DELETENEW } from 'scheduler-app/lib/api';

export const UserAPI = {
  get: GET('users'),
  get_current: GET('users/user'),
  create: POST('auth/onboard/login'),
  onboard: POST('auth/onboard'),
  status: PUT('users/user/status'),
  update: PUT('users/user'),
  update_password: PUT('/auth/password')
};

export const ScheduleUsersAPI = {
  get: GET('users/schedule'),
  update: PUT('users/schedule')
};

export const SessionAPI = {
  create: POST('auth/login'),
  forgot_password: POST('auth/forgotpassword'),
  reset_password: POST('auth/resetpassword'),
  onboard_login: POST('auth/onboard/login')
};

export const ScheduleAPI = {
  get: GET('schedule'),
  create: POST('schedule'),
  update: PUT('schedule'),
  delete: DELETE('schedule'),
  publish: POST('schedule/publish')
};

export const TimesheetsAPI = {
  get: GETNEW('timesheets/:user_id'),
  create: POSTNEW('timesheets/:user_id'),
  default: POSTNEW('timesheets/:user_id/default'),
  update: PUTNEW('timesheets/:user_id/:id'),
  delete: DELETENEW('timesheets/:user_id/:id')
};
export const PositionsAPI = {
  get: GET('positions'),
  create: POST('positions'),
  update: PUT('positions'),
  delete: DELETE('positions')
};

export const TemplateAPI = {
  get: GET('templates'),
  create: POST('templates'),
  update: PUT('templates'),
  delete: DELETE('templates')
};
