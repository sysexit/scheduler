import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import { ModalBody, ModalHeader } from 'reactstrap';

import Form from 'scheduler-app/containers/Form';
import { FormButton } from 'scheduler-app/components/form';
import fields from 'scheduler-app/components/form/fields';

import { addStaff, loadStaff } from 'scheduler-app/redux/staff';
import {
  updatePerson,
  addPerson,
  disablePerson,
  enablePerson
} from 'scheduler-app/admin/people/people';

class StaffManagement extends Component {
  state = {};

  add = (values) => {
    this.props.addPerson({ ...values });
    this.props.hideModal();
  };

  save = (values) => {
    this.props.updatePerson({ ...values });
    this.props.hideModal();
  };

  archive = ({ email }) => {
    this.props.disablePerson(email);
    this.props.hideModal();
  };

  enable = ({ email }) => {
    this.props.enablePerson(email);
    this.props.hideModal();
  };

  existingEmployee = ({ values }) => {
    if (!this.props.user) return null;
    return (
      <>
        {this.props.user.enabled ? (
          <FormButton
            color="danger"
            type="button"
            onClick={() => this.archive(values)}
          >
            Archive Employee
          </FormButton>
        ) : (
          <FormButton
            color="success"
            type="button"
            onClick={() => this.enable(values)}
          >
            Enable Employee
          </FormButton>
        )}
      </>
    );
  };

  render() {
    const { user, positions } = this.props;

    const initialValues = user
      ? {
        ...user,
        userid: user.id
      }
      : {};

    const formFields = [
      ...fields.staffmanage,
      {
        name: 'email',
        type: 'email',
        title: 'Email',
        required: true,
        placeholder: 'Email',
        readOnly: user && user.email ? !!user.email : false
      },
      {
        name: 'positions',
        type: 'select',
        title: 'Positions',
        required: true,
        multiple: true,
        options: positions.map((position) => ({
          name: position.title,
          value: position.id
        }))
      }
    ];

    const onSubmit = user ? this.save : this.add;
    const submitTitle = user ? 'Save' : 'Add Employee';

    return (
      <div>
        <ModalBody>
          <ModalHeader toggle={this.props.hideModal}>
            {user ? 'Update employee' : 'Add employee'}
          </ModalHeader>
          <Form
            fields={formFields}
            submitTitle={submitTitle}
            onSubmit={onSubmit}
            initialValues={initialValues}
            additionalButtonsPost={this.existingEmployee}
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
      addStaff: (staff) => {
        dispatch(addStaff({ staff }));
      },
      loadStaff: (type) => {
        dispatch(loadStaff({ type }));
      },
      updatePerson: (user) => {
        dispatch(updatePerson({ user }));
      },
      addPerson: (user) => {
        dispatch(addPerson({ user }));
      },
      disablePerson: (email) => {
        dispatch(disablePerson({ email }));
      },
      enablePerson: (email) => {
        dispatch(enablePerson({ email }));
      }
    };
  }
)(StaffManagement);
