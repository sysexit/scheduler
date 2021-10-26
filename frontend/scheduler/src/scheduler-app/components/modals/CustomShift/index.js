import React from 'react';
import { connect } from 'react-redux';
import { ModalBody, ModalHeader } from 'reactstrap';
import _ from 'lodash/core';
import { cloneDeep } from 'lodash';

import Form from 'scheduler-app/containers/Form';
import fields from 'scheduler-app/components/form/fields';

import {
  addSchedule,
  updateSchedule,
  deleteSchedule
} from 'scheduler-app/schedule/schedule';
import { DAYS, MONTHS, SHIFT_MODAL_TYPE } from 'scheduler-app/lib/constants';
import { getPosition, timeToDate } from 'scheduler-app/utils/helpers';

import { addTemplate } from 'scheduler-app/redux/templates';
import { scheduleUsersSelector } from 'scheduler-app/selectors/staff';

import SaveTemplate from './SaveTemplateButton';
import DeleteShift from './DeleteShiftButton';

class CustomShift extends React.Component {
  addShift = (values) => {
    const { type, addSchedule, updateSchedule } = this.props;
    if (type == SHIFT_MODAL_TYPE.ADD) {
      addSchedule(this.shiftData(values));
    } else if (type == SHIFT_MODAL_TYPE.EDIT) {
      updateSchedule(this.shiftData(values));
    }
  };

  onSubmit = (values) => {
    const { savetemplate, start, end, position } = values;
    this.addShift(values);
    this.props.closeModal();
    if (savetemplate) {
      this.props.addTemplate({ start, end, position });
    }
  };

  onDelete = () => {
    this.props.deleteSchedule(this.props.id);
    this.props.closeModal();
  };

  // TODO: Perhaps data validation
  shiftData(values) {
    const { date } = this.props;
    const { id, user, start, end, position } = values;
    return {
      id,
      userid: user,
      start: timeToDate(start, date),
      end: timeToDate(end, date),
      position: position
    };
  }

  additionalButtons = (props) => (
    <>
      {this.props.shift ? (
        <DeleteShift
          {...props}
          deleteSchedule={this.props.deleteSchedule}
          closeModal={this.props.closeModal}
        />
      ) : (
        <SaveTemplate />
      )}
    </>
  );

  render() {
    const { date, shift, scheduleStaff, staff, positions, closeModal } =
      this.props;

    const day = DAYS[date.getDay()];
    const month = MONTHS[date.getMonth()];
    const header = `Create Shift on ${day}, ${date.getDate()} ${month}`;
    const formFields = cloneDeep(fields.shift);

    const start = shift ? shift.start : '12:00';
    const end = shift ? shift.end : '12:00';
    const position = shift ? shift.position : null;
    const user = this.props.user || shift.user;

    let initialValues = {
      user,
      start,
      end,
      position
    };

    if (shift && shift.id)
      initialValues = {
        ...initialValues,
        id: shift.id,
        position: shift.position,
        type: SHIFT_MODAL_TYPE.EDIT
      };

    const currentUser = _.find(staff, (_user) => _user.id == user);

    const userPositions = currentUser.positions.map((position) => {
      const title = getPosition(position, positions);
      return { name: title, value: position };
    });
    const scheduleUsersDisplay = scheduleStaff.map((user) => ({
      name: user.display || `${user.first} ${user.last}`,
      value: user.id
    }));

    const formUsers = _.find(formFields, (o) => o.name == 'user');
    const formPositions = _.find(formFields, (o) => o.name == 'position');

    formUsers.options = scheduleUsersDisplay;
    formPositions.options = [...formPositions.options, ...userPositions];

    return (
      <div>
        <ModalBody>
          <ModalHeader toggle={closeModal}>{header}</ModalHeader>
          <Form
            fields={formFields}
            onSubmit={this.onSubmit}
            cancelTitle={'Close'}
            onCancel={closeModal}
            initialValues={initialValues}
            additionalButtonsPre={this.additionalButtons}
            isModal={true}
          />
        </ModalBody>
      </div>
    );
  }
}

export default connect(
  (state) => {
    return {
      scheduleStaff: scheduleUsersSelector(state),
      staff: state.staff,
      positions: state.positions,
      schedule: state.schedule
    };
  },
  (dispatch) => {
    return {
      addSchedule: (shift) => {
        dispatch(addSchedule({ shift }));
      },
      updateSchedule: (shift) => {
        dispatch(updateSchedule({ shift }));
      },
      deleteSchedule: (id) => {
        dispatch(deleteSchedule({ id }));
      },
      addTemplate: (template) => {
        dispatch(addTemplate({ template }));
      }
    };
  }
)(CustomShift);
