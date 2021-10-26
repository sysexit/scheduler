import React, { useContext } from 'react';
import _ from 'lodash/core';

import Can from 'scheduler-app/components/Can';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

const dayTotals = (schedule) => {
  return _.reduce(
    schedule,
    (result, shifts, day) => {
      result[day] = _.reduce(
        shifts,
        (sum, shift) => {
          return sum + shift.length;
        },
        0
      );
      return result;
    },
    {}
  );
};

const AdminTotal = ({ start, weekTotals, assignedTotal }) => (
  <div class="table-row table-foot">
    <div class="table-cell date-cell">Assigned total {assignedTotal} hours</div>
    {[...Array(7)].map((x, day) => {
      let date = new Date(start);
      date.setDate(date.getDate() + day);
      const total = weekTotals[date.toDateString()] || 0;
      return <div class="table-cell date-cell">{total}</div>;
    })}
  </div>
);

const UserTotal = () => (
  <div class="table-row table-foot">
    <div class="table-cell date-cell"></div>
    {[...Array(7)].map((x) => {
      return <div class="table-cell date-cell"></div>;
    })}
  </div>
);

const WeekTotal = () => {
  const context = useContext(ScheduleContext);
  const { group, start, schedule } = context;

  const weekTotals = dayTotals(schedule);
  const assignedTotal = _.reduce(weekTotals, (sum, total) => sum + total, 0);

  return (
    <Can
      role={group}
      perform="schedule:hours-total"
      yes={() => (
        <AdminTotal
          weekTotals={weekTotals}
          assignedTotal={assignedTotal}
          start={start}
        />
      )}
      no={() => <UserTotal />}
    />
  );
};

export default WeekTotal;
