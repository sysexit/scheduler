import React from 'react';

import UserAvatar from 'scheduler-app/components/UserAvatar';

const User = ({ user, children }) => {
  const display = user.display || `${user.first} ${user.last}`;
  return (
    <tr key={user.id}>
      <td className="ml-0 row">
        <span className="text-white inline-block">
          <UserAvatar />
        </span>{' '}
        <span className="ml-2 text-bold">{display}</span>
      </td>
      <td>{user.email}</td>
      {children}
    </tr>
  );
};

export default User;
