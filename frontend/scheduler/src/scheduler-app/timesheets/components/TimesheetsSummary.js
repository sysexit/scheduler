import React from 'react';
import r from 'lodash/round';

import TimesheetContext from 'scheduler-app/timesheets/TimesheetContext';

class TimesheetsSummary extends React.Component {
  static contextType = TimesheetContext;

  calculateHours() {
    const { timesheets } = this.props;
    const { timesheetsTotalByDay } = this.context;

    if (!timesheets) return null;
    let result = {
      week: 0,
      weekend: 0
    };

    Object.keys(timesheetsTotalByDay).map((k) => {
      const day = new Date(k).getDay();

      if (day == 0 || day == 6) {
        result['weekend'] += timesheetsTotalByDay[k];
        return;
      }

      result['week'] += timesheetsTotalByDay[k];
    });

    // Round
    result = {
      week: r(result.week),
      weekend: r(result.weekend)
    };

    return result;
  }

  render() {
    const hoursSum = this.calculateHours();
    if (hoursSum == null) return null;
    const weekSum = hoursSum['week'];
    const weekendSum = hoursSum['weekend'];
    let overtimeSum = weekSum - 38;

    if (overtimeSum <= 0) overtimeSum = 0;

    return (
      <div style={{ display: 'flex' }}>
        <HourTotal label="Week Total" total={weekSum} />
        <HourTotal label="Weekend Total" total={weekendSum} />
        <HourTotal label="Overtime" total={overtimeSum} />
      </div>
    );
  }
}

const HourTotal = ({ label, total }) => (
  <div class="hour-type-total">
    <span class="hour-type-label">{label} </span>
    {total}
  </div>
);

export default TimesheetsSummary;
