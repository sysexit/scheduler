import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

class AddNewUser extends Component {
  static contextType = ScheduleContext;

  render() {
    return (
      <div class="table-row">
        <div
          className="table-cell date-cell"
          style={{ color: 'darkred', cursor: 'pointer' }}
        >
          <Link to="/admin/people">Add user to schedule</Link>
        </div>
        {[...Array(7)].map((x) => {
          return (
            <div className="table-cell date-cell">
              <div className="shift-holder" />
            </div>
          );
        })}
      </div>
    );
  }
}

export default AddNewUser;
