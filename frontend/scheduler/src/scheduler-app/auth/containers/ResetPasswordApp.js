import React from 'react';
import { Helmet } from 'react-helmet';

import { ListError } from 'scheduler-app/components/ListErrors';
import { SessionAPI } from '../../services';
import AuthLayout from '../components/AuthLayout';
import Form from 'scheduler-app/containers/Form';
import { PASSWORD_FIELDS } from 'scheduler-app/user/form';
import { withRouter } from '../components/WithRouter';
import { getParam } from '../../utils/helpers';

class ResetPassword extends React.Component {
  state = {};

  setError(error) {
    this.setState({ error });
  }

  getParam = (param) => {
    return getParam(this.props.location, param);
  };

  onSubmit = async ({ new_password, confirm_password }) => {
    const token = this.getParam('token');
    const email = this.getParam('email');

    if (new_password !== confirm_password) {
      this.setError('Passwords do not match.');
      return;
    }

    const result = await SessionAPI.reset_password({
      token,
      email,
      password: new_password,
      passwordconfirm: confirm_password,
    });

    if (result.status == 'ok') {
      window.location = '/login';
    } else {
      this.setError(result.message);
    }
  };

  render() {
    this.getParam('token');
    this.getParam('email');

    const fields = PASSWORD_FIELDS;

    return (
      <AuthLayout>
        <Helmet>
          <title>Reset password</title>
        </Helmet>
        <div class="title">
          <h1>Reset password</h1>
        </div>
        <div class="login no-center">
          {this.state.error && <ListError error={this.state.error} />}
          <Form
            fields={fields}
            submitTitle={'Reset password'}
            onSubmit={this.onSubmit}
          />
        </div>
      </AuthLayout>
    );
  }
}

export default withRouter(ResetPassword);
