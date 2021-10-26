import React, { Component } from 'react';

import ShiftContainer from './ShiftContainer';
import Shift from './Shift';

import { GROUP } from 'scheduler-app/lib/permissions';
import { SHIFT_MODAL_TYPE, VIEW_TYPE } from 'scheduler-app/lib/constants';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

export default class ScheduleList extends Component {
  static contextType = ScheduleContext;

  containerModalData(userid, date) {
    const { hideModal } = this.context;
    return {
      open: true,
      closeModal: hideModal,
      user: userid,
      date,
      type: SHIFT_MODAL_TYPE.ADD
    };
  }

  shiftLength(shift) {
    const { view } = this.context;
    if (view == VIEW_TYPE.WEEK) return 100;

    let start = new Date(shift.start);
    let end = new Date(shift.end);
    return (end.getHours() - start.getHours()) * 100;
  }

  render() {
    const { view, group } = this.context;

    const { schedule, date, user } = this.props;

    let modalData = null;
    const viewDate = new Date(date);
    const noShifts = schedule.length == 0; // No schedule in the current day/hour
    const allowAddShift = noShifts && group == GROUP.ADMIN;

    if (allowAddShift) {
      modalData = this.containerModalData(user.id, viewDate);
    }

    return (
      <ShiftContainer
        allowAddShift={allowAddShift}
        date={viewDate}
        modalData={modalData}
      >
        {schedule.length > 0 &&
          schedule.map((shift) => (
            <Shift
              shift={shift}
              date={viewDate}
              width={this.shiftLength(shift)}
            />
          ))}
      </ShiftContainer>
    );
  }
}
