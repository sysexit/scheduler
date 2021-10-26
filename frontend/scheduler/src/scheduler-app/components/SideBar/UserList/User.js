import React from 'react';
import UserAvatar from 'scheduler-app/components/UserAvatar';

class User extends React.Component {
  onClick = () => {
    const { user, setTimesheetUser } = this.props;
    setTimesheetUser(user.id);
  };

  render() {
    const { user } = this.props;

    return (
      <div class="timesheet-user" onClick={this.onClick}>
        <div class="row no-gutters align-items-center timesheet-user-item selected has-times">
          <div class="col-auto avatar">
            <UserAvatar />
          </div>
          <div class="pl-2 col-auto">
            {user.display ? user.display : `${user.first} ${user.last}`}
          </div>
        </div>
      </div>
    );
  }
}

export default User;
