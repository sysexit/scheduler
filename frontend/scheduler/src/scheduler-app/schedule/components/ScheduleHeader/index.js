import React from 'react';
import DayHeader from './DayHeader';
import WeekHeader from './WeekHeader';

const ViewType = {
  Day: DayHeader,
  Week: WeekHeader
};

class ScheduleHeader extends React.Component {
  render() {
    const { view, start } = this.props;
    const Header = ViewType[view];

    return <Header start={start} />;
  }
}

export default ScheduleHeader;
