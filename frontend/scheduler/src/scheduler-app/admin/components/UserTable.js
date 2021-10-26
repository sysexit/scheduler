import React, { Component } from 'react';

import User from 'scheduler-app/admin/components/User';

const UserTable = ({ users, children }) => {
  const hasUsers = users.length > 0;
  const EditOptions = editOptions;

  return (
    <table className="w-100">
      <thead>
        <tr>
          <th>Name</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        {hasUsers &&
          users.map((user) => (
            <User user={user} editUser>
              <EditOptions user={user}>{children}</EditOptions>
            </User>
          ))}
      </tbody>
    </table>
  );
}

const editOptions = ({ children, user }) => {
  if (typeof children === 'function') {
    return children({
      user
    });
  }
  return { children };
};

export default UserTable;
