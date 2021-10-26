import React from 'react';

import { DAYS } from 'scheduler-app/lib/constants';

class WeekHeader extends React.Component {
  render() {
    return (
      <div class="table-row table-head">
        <div class="table-cell date-cell"></div>
        {[...Array(7)].map((x, day) => {
          let date = new Date(this.props.start);
          date.setDate(date.getDate() + day);
          return <HeaderDay date={date} />;
        })}
      </div>
    );
  }
}

class HeaderDay extends React.Component {
  render() {
    let date = this.props.date;
    let day = DAYS[date.getDay()];
    return (
      <div class="table-cell date-cell">
        <span>
          {day} {date.getDate()}
        </span>
      </div>
    );
  }
}

export default WeekHeader;
