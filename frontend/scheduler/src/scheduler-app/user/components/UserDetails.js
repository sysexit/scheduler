import React, { Component } from 'react';
import { cloneDeep } from 'lodash';

import Form from 'scheduler-app/containers/Form';
import form from '../form';

class UserApp extends Component {
  onSubmit = (values) => {
    this.props.updateUserDetails(values);
  };

  render() {
    const { user } = this.props;
    const formFields = cloneDeep(form.details);
    const initialValues = {
      email: user.email,
      first: user.first,
      last: user.last
    };

    return (
      <div>
        <Form
          fields={formFields}
          onSubmit={this.onSubmit}
          initialValues={initialValues}
        />
      </div>
    );
  }
}

export default UserApp;
