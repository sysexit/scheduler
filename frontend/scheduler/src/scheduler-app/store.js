import { combineReducers, applyMiddleware, compose, createStore } from 'redux';
import { configureStore } from '@reduxjs/toolkit';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { createBrowserHistory } from 'history';

import timesheets from 'scheduler-app/timesheets/timesheets';
import schedule from 'scheduler-app/schedule/schedule';
import auth from 'scheduler-app/auth/auth';
import admin from 'scheduler-app/admin/admin';

import modal from 'scheduler-app/redux/modal';
import templates from 'scheduler-app/redux/templates';
import staff from 'scheduler-app/redux/staff';
import view from 'scheduler-app/redux/view';
import currentUser from 'scheduler-app/redux/user';
import user from 'scheduler-app/user/user';
import positions from 'scheduler-app/redux/positions';

export const history = createBrowserHistory();

const reducer = (history) =>
  combineReducers({
    router: connectRouter(history),
    auth,
    admin,
    schedule,
    timesheets,
    currentUser,
    user,
    templates,
    modal,
    staff,
    view,
    positions
  });

export default function initStore() {
  return configureStore({
    reducer: reducer(history)
    // middleware: applyMiddleware(routerMiddleware(history))
  });
}
