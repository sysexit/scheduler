import React, { Component } from 'react';
import { cloneDeep } from 'lodash';

import form from '../form';
import Form from 'scheduler-app/containers/Form';

class UserPassword extends Component {
  onSubmit = (values) => {
    console.log(values)
    this.props.updateUserPassword(values);
  };

  render() {
    const formFields = cloneDeep(form.password);

    return (
      <div>
        <Form
          fields={formFields}
          onSubmit={this.onSubmit}
          submitTitle="Update password"
        />
      </div>
    );
  }
}

export default UserPassword;
