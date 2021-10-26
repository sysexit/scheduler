import React from 'react';
import classNames from 'clsx';

import { VIEW_TYPE } from 'scheduler-app/lib/constants';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

class ShiftContainer extends React.Component {
  static contextType = ScheduleContext;

  onClick = () => {
    const { showModal } = this.context;
    const { modalData } = this.props;
    if (!modalData) return;
    showModal(modalData, 'ShiftFromTemplate');
  };

  render() {
    const { allowAddShift, date } = this.props;
    const { view } = this.context;
    const dayView = view == VIEW_TYPE.DAY;
    const today = new Date().toDateString() == date.toDateString();

    return (
      <div
        className={classNames({
          'table-cell': true,
          'hour-cell': dayView,
          'date-cell': !dayView,
          'show-plus': allowAddShift,
          'highlight-cell': today
        })}
        onClick={this.onClick}
      >
        <div className="shift-holder">{this.props.children}</div>
      </div>
    );
  }
}

export default ShiftContainer;
