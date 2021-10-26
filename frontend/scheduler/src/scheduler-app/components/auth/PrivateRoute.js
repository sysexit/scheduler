import React from 'react';
import { Navigate, Route } from 'react-router-dom';

import { getCurrentUser } from 'scheduler-app/utils/helpers';

const PrivateRoute = ({ group = 1, ...props }) => {
  const user = getCurrentUser();
  if (user !== null) {
    if (user.group <= group) return <Route {...props} />;
    else return <Navigate to="/" />;
  }
  return <Navigate to="/login" />;
};

export default PrivateRoute;
