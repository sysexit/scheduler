import React, { Component, useContext } from 'react';
import filter from 'lodash/filter';
import r from 'lodash/round';

import Timesheet from './Timesheet';
import { formatDatetime, getHourText } from 'scheduler-app/utils/helpers';
import TimesheetContext from 'scheduler-app/timesheets/TimesheetContext';

export default class TimesheetsGrid extends Component {
  f = (start, date) => {
    return new Date(start).toDateString() == date.toDateString();
  };

  render() {
    const { start, timesheets, schedule, userid } = this.props;

    return (
      <div>
        {[...Array(7)].map((x, i) => {
          const newDate = new Date(start);
          newDate.setDate(newDate.getDate() + i);

          const filteredTimesheets = filter(timesheets, (ts) =>
            this.f(ts.start, newDate)
          );
          const userShifts = filter(schedule, (s) => this.f(s.start, newDate));

          return (
            <TimesheetDay
              date={newDate}
              userid={userid}
              timesheets={filteredTimesheets}
              schedule={userShifts}
            />
          );
        })}
      </div>
    );
  }
}

const TimesheetDay = ({ timesheets, date, userid, schedule }) => {
  const context = useContext(TimesheetContext);
  const { timesheetsTotalByDay, scheduledTotalByDay } = context;

  const timesheetDateTotal =
    r(timesheetsTotalByDay[date.toDateString()], 2) || 0;
  const scheduledDateTotal =
    r(scheduledTotalByDay[date.toDateString()], 2) || 0;
  const scheduledDifference = r(timesheetDateTotal - scheduledDateTotal, 2);
  const day = formatDatetime(date);

  return (
    <div class="table-row table-footer timesheet">
      <div class="table-cell date-cell">{day}</div>
      <div class="subrow-container">
        <TimesheetList timesheets={timesheets} date={date} userid={userid}>
          <ScheduleList schedule={schedule} />
        </TimesheetList>
      </div>
      <div class="table-cell date-cell">{timesheetDateTotal}</div>
      <div class="table-cell date-cell">{scheduledDateTotal}</div>
      <div class="table-cell date-cell">{scheduledDifference}</div>
    </div>
  );
};

const ScheduleList = ({ schedule }) => {
  return schedule.map((shift) => <ScheduledShift shift={shift} />);
};

const TimesheetList = ({ timesheets, date, userid, children }) => {
  if (!timesheets || timesheets.length == 0) {
    return (
      <>
        <Timesheet date={date} userid={userid} />
        {children}
      </>
    );
  }

  return (
    <>
      {timesheets.map((timesheet, i) => {
        if (i < timesheets.length - 1)
          return (
            <Timesheet date={date} timesheet={timesheet} userid={userid} />
          );

        return (
          <>
            <Timesheet date={date} timesheet={timesheet} userid={userid} />
            <Timesheet date={date} userid={userid} />
          </>
        );
      })}
      {children}
    </>
  );
};

const ScheduledShift = (props) => {
  const { start, end } = props.shift;
  const startDate = new Date(start);
  const endDate = new Date(end);
  const total = (endDate - startDate) / 1000 / 60 / 60;
  return (
    <div class="subrow scheduled-shift-cell">
      <div class="subrow-item">{getHourText(start)}</div>
      <div class="subrow-item">{getHourText(end)}</div>
      <div class="subrow-item">{total}</div>
    </div>
  );
};
