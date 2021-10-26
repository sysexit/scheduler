import React from 'react';
import r from 'lodash/round';

import TimesheetContext from 'scheduler-app/timesheets/TimesheetContext';

class TimesheetsFooter extends React.Component {
  static contextType = TimesheetContext;

  render() {
    const { timesheetsTotal, scheduledTotal } = this.context;

    const scheduledDifference = r(timesheetsTotal - scheduledTotal, 2);
    return (
      <div>
        <div class="table-row table-foot">
          <div class="table-cell date-cell">Total</div>
          <div class="table-cell date-cell"></div>
          <div class="table-cell date-cell"></div>
          <div class="table-cell date-cell">{timesheetsTotal}</div>
          <div class="table-cell date-cell">{timesheetsTotal}</div>
          <div class="table-cell date-cell">{scheduledTotal}</div>
          <div class="table-cell date-cell">{scheduledDifference}</div>
        </div>
      </div>
    );
  }
}

export default TimesheetsFooter;
