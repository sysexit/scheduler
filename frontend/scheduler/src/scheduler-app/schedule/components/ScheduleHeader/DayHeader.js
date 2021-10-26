import React from 'react';

export default class DayHeader extends React.Component {
  render() {
    return (
      <div class="table-row table-head">
        <div class="table-cell hour-cell"></div>
        {[...Array(23)].map((x, hour) => {
          if (hour < 4 || hour > 20) return;

          return <HeaderHour hour={hour} />;
        })}
      </div>
    );
  }
}

class HeaderHour extends React.Component {
  getHour(hour) {
    let hours = ['A', 'P'];
    let value = ((hour + 1) % 12) + hours[Math.floor((hour + 1) / 12)];

    if (hour + 1 == 12) {
      value = '12P';
    }
    if (hour + 1 == 24) {
      value = '12A';
    }

    return value;
  }

  render() {
    return (
      <div class="table-cell hour-cell">
        <span>{this.getHour(this.props.hour)}</span>
      </div>
    );
  }
}
