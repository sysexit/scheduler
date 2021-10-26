import React from 'react';

import EditShiftButton from 'scheduler-app/schedule/components/buttons/EditShiftButton';
import { SHIFT_MODAL_TYPE } from 'scheduler-app/lib/constants';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

class ShiftActions extends React.Component {
  static contextType = ScheduleContext;

  closeModal = () => {
    this.context.hideModal();
  };

  openEditShiftModal = (data) => {
    this.context.showModal(data, 'CustomShift');
  };

  toTimeString(time) {
    return new Date(time).toTimeString().split(':').slice(0, 2).join(':');
  }

  render() {
    const { shift, date, colour } = this.props;

    let data = {
      open: true,
      closeModal: this.closeModal,
      date,
      shift: {
        ...shift,
        user: shift.userid,
        start: this.toTimeString(shift.start),
        end: this.toTimeString(shift.end)
      },
      type: SHIFT_MODAL_TYPE.EDIT
    };

    return (
      <div className="actions col">
        <div className="row no-gutters h-100">
          <div></div>
          <div className="col h-100">
            <div
              className="row action-button-row no-gutters align-items-center h-100"
              style={{ backgroundColor: colour }}
            >
              <EditShiftButton
                handleClick={this.openEditShiftModal}
                data={data}
              />
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default ShiftActions;
