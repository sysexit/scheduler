import React from 'react';

import User from './User';

class UserList extends React.Component {
  render() {
    const { staff, setTimesheetUser, loadTimesheets } = this.props;

    return (
      <div>
        {staff
          // .filter((member) => member.su)
          .map((member) => (
            <User
              user={member}
              setTimesheetUser={setTimesheetUser}
              loadTimesheets={loadTimesheets}
            />
          ))}
      </div>
    );
  }
}

export default UserList;
