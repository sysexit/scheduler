import React from 'react';
import { Badge } from 'reactstrap';
import classNames from 'clsx';

import ColAddShift from './ColAddShift';
import {
  SHIFT_MODAL_TYPE,
  SHIFT_COLOR,
  VIEW_TYPE
} from 'scheduler-app/lib/constants';
import { getPosition } from 'scheduler-app/utils/helpers';
import { getHourText } from 'scheduler-app/utils/helpers';
import Can from 'scheduler-app/components/Can';
import ShiftActions from './ShiftActions';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

class Shift extends React.Component {
  static contextType = ScheduleContext;

  state = {
    width: 100
  };

  componentDidMount() {
    if (this.props.width) {
      this.setState({ width: this.props.width });
    }
  }

  componentDidUpdate(prevProps) {
    if (this.props.width !== prevProps.width) {
      this.setState({ width: this.props.width });
    }
  }

  getStyle = () => {
    return {
      width: this.state.width + '%'
    };
  };

  closeModal = () => {
    this.context.hideModal();
  };

  openAddShiftModal = (data) => {
    this.context.showModal(data, 'ShiftFromTemplate');
  };

  getShiftText(shift) {
    return getHourText(shift.start) + ' - ' + getHourText(shift.end);
  }

  addShift(data) {
    return <ColAddShift handleClick={this.openAddShiftModal} value={data} />;
  }

  render() {
    const { shift, date } = this.props;
    const { positions, group, showModal, hideModal } = this.context;

    const position = getPosition(shift.position, positions);
    const colour = SHIFT_COLOR[shift.position - 1];
    const published = shift.published;

    let modalData = {
      open: true,
      closeModal: this.closeModal,
      date,
      user: shift.userid,
      type: SHIFT_MODAL_TYPE.ADD
    };

    return (
      <div>
        <div
          className="shift-item row no-gutters can-schedule"
          style={this.getStyle()}
        >
          <div className="details-container row no-gutters h-100">
            <Can
              role={group}
              perform="schedule:modify"
              yes={() => (
                <ShiftActions
                  shift={shift}
                  date={date}
                  showModal={showModal}
                  hideModal={hideModal}
                  colour={colour}
                />
              )}
            />
            <div
              className={classNames({
                'not-published': !published,
                'details col text-white': true
              })}
              style={{ 'background-color': colour, 'border-color': colour }}
            >
              <div className="row no-gutters align-items-center">
                <div className="col-auto">{this.getShiftText(shift)}</div>
                <span className="tag shift-tag col-auto text-truncate">
                  {' '}
                  <Badge color="secondary">{position}</Badge>
                </span>
              </div>
            </div>
          </div>
          <Can
            role={group}
            perform="schedule:modify"
            yes={() => this.addShift(modalData)}
          />
        </div>
      </div>
    );
  }
}

export default Shift;
