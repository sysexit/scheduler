import React from 'react';
import { Navigate } from 'react-router-dom';
import { logout } from 'scheduler-app/utils/helpers';

class Logout extends React.Component {
  render() {
    logout();
    return <Navigate to="/login" />;
  }
}

export default Logout;
