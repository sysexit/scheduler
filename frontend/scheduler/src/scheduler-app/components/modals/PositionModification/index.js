import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import { ModalBody, ModalHeader } from 'reactstrap';

import Form from 'scheduler-app/containers/Form';
import {
  addPosition,
  disablePosition,
  enablePosition
} from 'scheduler-app/admin/positions/positions';

class PositionModification extends Component {
  add = (values) => {
    this.props.addPosition({ ...values });
    this.props.hideModal();
  };

  archive = ({ id }) => {
    this.props.disablePosition(id);
    this.props.hideModal();
  };

  enable = ({ id }) => {
    this.props.enablePosition(id);
    this.props.hideModal();
  };

  render() {
    const { position } = this.props;

    const initialValues = position
      ? {
          ...position
        }
      : {};

    const formFields = [
      {
        name: 'position',
        type: 'text',
        title: 'Position Title',
        placeholder: 'Cook',
        readOnly: position ? true : false
      }
    ];

    const onSubmit = position
      ? position.enabled
        ? this.archive
        : this.enable
      : this.add;
    const submitTitle = position
      ? position.enabled
        ? 'Archive Position'
        : 'Enable position'
      : 'Add Position';
    const submitColor = position
      ? position.enabled
        ? 'danger'
        : 'success'
      : 'primary';

    return (
      <div>
        <ModalBody>
          <ModalHeader toggle={this.props.hideModal}>
            {position ? 'Update position' : 'Add position'}
          </ModalHeader>
          <Form
            fields={formFields}
            submitTitle={submitTitle}
            onSubmit={onSubmit}
            submitColor={submitColor}
            initialValues={initialValues}
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
      positions: state.positions
    };
  },
  (dispatch) => {
    return {
      addPosition: (position) => {
        dispatch(addPosition({ position }));
      },
      disablePosition: (positionid) => {
        dispatch(disablePosition({ positionid }));
      },
      enablePosition: (positionid) => {
        dispatch(enablePosition({ positionid }));
      }
    };
  }
)(PositionModification);
