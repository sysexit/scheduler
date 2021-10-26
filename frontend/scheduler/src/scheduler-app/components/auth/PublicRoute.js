import React from 'react';
import { Navigate, Route } from 'react-router-dom';

import { getCurrentUser } from 'scheduler-app/utils/helpers';

const PublicRoute = ({ restricted, ...props }) => {
  if (getCurrentUser() !== null) {
    if (restricted) {
      return <Navigate to="/" />;
    }
  }

  return <Route {...props} />;
};

export default PublicRoute;
