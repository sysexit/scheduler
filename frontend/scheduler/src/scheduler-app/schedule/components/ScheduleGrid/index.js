import React, { Component, useContext } from 'react';
import _ from 'lodash/core';

import UserInfoCell from './UserInfoCell';
import AddNewUser from './AddNewUser';
import ScheduleList from './ScheduleList';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';
import Can from 'scheduler-app/components/Can';
import { VIEW_TYPE } from 'scheduler-app/lib/constants';

class ScheduleGrid extends Component {
  static contextType = ScheduleContext;

  render() {
    const { staff, view, group, positions } = this.context;

    if (!staff || !positions || staff.length == 0 || positions.length == 0)
      return null;

    return (
      <>
        {staff.map((user) => (
          <div class="table-row">
            <UserInfoCell user={user} />
            <ScheduleRow user={user} />
          </div>
        ))}
        <Can
          role={group}
          perform="admin:add-user"
          yes={() => view == VIEW_TYPE.WEEK && <AddNewUser />}
        />
      </>
    );
  }
}

const ScheduleRow = ({ user }) => {
  const context = useContext(ScheduleContext);
  const { schedule, start, viewStart, view } = context;
  const keys = Object.keys(schedule);
  const values = Object.values(schedule);

  const valuesFiltered = values.map((v) => _.filter(v, { userid: user.id }));
  let userSchedule = {};
  for (var i = 0; i < keys.length; i++) {
    userSchedule[keys[i]] = valuesFiltered[i];
  }

  if (view == VIEW_TYPE.DAY) {
    return <DayRow start={viewStart} schedule={userSchedule} user={user} />;
  } else if (view == VIEW_TYPE.WEEK) {
    return <WeekRow start={start} schedule={userSchedule} user={user} />;
  }
};

const DayRow = ({ start, schedule, user }) => {
  return [...Array(23)].map((x, hour) => {
    if (hour < 4 || hour > 20) return;
    const list = schedule[hour + 1] || [];
    return <ScheduleList schedule={list} date={start} user={user} />;
  });
};

const WeekRow = ({ start, schedule, user }) => {
  return [...Array(7)].map((x, day) => {
    const date = new Date(start);
    date.setDate(date.getDate() + day);
    const list = schedule[date.toDateString()] || [];
    return <ScheduleList schedule={list} date={date} user={user} />;
  });
};

export default ScheduleGrid;
