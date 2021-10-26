import React from 'react';

class TimesheetsHeader extends React.Component {
  render() {
    return (
      <div>
        <div class="table-row table-head">
          <div class="table-cell date-cell">Day</div>
          <div class="table-cell date-cell">In</div>
          <div class="table-cell date-cell">Out</div>
          <div class="table-cell date-cell">Total</div>
          <div class="table-cell date-cell">Worked</div>
          <div class="table-cell date-cell">Scheduled</div>
          <div class="table-cell date-cell">Difference</div>
        </div>
      </div>
    );
  }
}

export default TimesheetsHeader;
