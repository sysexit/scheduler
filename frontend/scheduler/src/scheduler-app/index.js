import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';

import 'scheduler-app/styles/style.scss';

import store, { history } from './store';
import App from './App';

import ScheduleApp from 'scheduler-app/schedule/containers/ScheduleApp';
import TimesheetsApp from 'scheduler-app/timesheets/containers/TimesheetsApp';

import AdminApp from 'scheduler-app/admin/containers/AdminApp';
import PeopleApp from 'scheduler-app/admin/people/containers/PeopleApp';

import UserApp from 'scheduler-app/user/containers/UserApp';

import LoginApp from 'scheduler-app/auth/containers/LoginApp';
import LogoutApp from 'scheduler-app/auth/containers/LogoutApp';
import OnboardApp from 'scheduler-app/auth/containers/OnboardApp';
import ForgotPasswordApp from 'scheduler-app/auth/containers/ForgotPasswordApp';
import ResetPasswordApp from 'scheduler-app/auth/containers/ResetPasswordApp';

import NotFound from 'scheduler-app/containers/NotFound';

import PublicRoute from 'scheduler-app/components/auth/PublicRoute';
import PrivateRoute from 'scheduler-app/components/auth/PrivateRoute';
import PositionsApp from './admin/positions/containers/PositionsApp';

ReactDOM.render(
  <Provider store={store()}>
    <ConnectedRouter history={history}>
      <Router>
        <App>
          <Routes>
            <PrivateRoute path="/" element={<ScheduleApp />} />
            <PrivateRoute path="schedule" element={<ScheduleApp />} />
            <PrivateRoute path="timesheets" element={<TimesheetsApp />} />

            <PrivateRoute path="admin" element={<AdminApp />} group={0}>
              <PrivateRoute path="/" element={<PeopleApp />} />
              <PrivateRoute path="people" element={<PeopleApp />} />
              <PrivateRoute path="positions" element={<PositionsApp />} />
            </PrivateRoute>

            <PrivateRoute path="user" element={<UserApp />} />

            <PrivateRoute path="logout" element={<LogoutApp />} />
            <PublicRoute path="login" restricted element={<LoginApp />} />
            <PublicRoute path="onboard" restricted element={<OnboardApp />} />
            <PublicRoute
              path="forgotpassword"
              restricted
              element={<ForgotPasswordApp />}
            />
            <PublicRoute
              path="resetpassword"
              restricted
              element={<ResetPasswordApp />}
            />

            <Route path="*" component={<NotFound />} />
          </Routes>
        </App>
      </Router>
    </ConnectedRouter>
  </Provider>,
  document.getElementById('root')
);
