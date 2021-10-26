import React, { Component } from 'react';

import DayTotal from './DayTotal';
import WeekTotal from './WeekTotal';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

const ViewType = {
  Day: DayTotal,
  Week: WeekTotal
};

class ScheduleFooter extends Component {
  static contextType = ScheduleContext;

  render() {
    const { view } = this.context;
    const Totals = ViewType[view];

    return (
      <ScheduleContext.Consumer>
        {({ test }) => <Totals {...this.props} />}
      </ScheduleContext.Consumer>
    );
  }
}

export default ScheduleFooter;
