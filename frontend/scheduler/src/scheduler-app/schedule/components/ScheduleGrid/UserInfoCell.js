import React, { Fragment } from 'react';
import classNames from 'clsx';
import _ from 'lodash/core';

import { VIEW_TYPE } from 'scheduler-app/lib/constants';
import Can from 'scheduler-app/components/Can';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

class UserInfoCell extends React.Component {
  static contextType = ScheduleContext;

  hoursTotal(userid) {
    const { schedule } = this.context;
    return _.reduce(
      schedule,
      (sum, item) => {
        return (
          sum +
          _.reduce(
            item,
            (sumsum, shift) => {
              if (shift.userid !== userid) return sumsum;
              const start = new Date(shift.start);
              const end = new Date(shift.end);
              return sumsum + (end - start) / 1000 / 60 / 60;
            },
            0
          )
        );
      },
      0
    );
  }

  render() {
    const { view, group } = this.context;
    const { user } = this.props;
    const dayView = view == VIEW_TYPE.DAY;

    return (
      <div
        className={classNames({
          'table-cell': true,
          'hour-cell': dayView,
          'date-cell': !dayView
        })}
      >
        {user.display ? user.display : user.first}
        <Can
          role={group}
          perform="schedule:hours-total"
          yes={() => {
            const hoursTotal = this.hoursTotal(user.id);

            return (
              <Fragment>
                <br />
                {hoursTotal}
              </Fragment>
            );
          }}
        />
      </div>
    );
  }
}

export default UserInfoCell;
