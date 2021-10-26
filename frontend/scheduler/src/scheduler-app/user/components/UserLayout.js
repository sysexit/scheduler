import React from 'react';

const UserLayout = ({ children }) => (
  <div class="container-fluid">
    <div class="box-container auth-container col-9 container content">
      {children}
    </div>
  </div>
);

export default UserLayout;
