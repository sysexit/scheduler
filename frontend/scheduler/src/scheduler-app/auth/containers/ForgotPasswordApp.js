import React from 'react';
import { Helmet } from 'react-helmet';

import { SessionAPI } from '../../services';
import AuthLayout from '../components/AuthLayout';
import Form from 'scheduler-app/containers/Form';

class ForgotPassword extends React.Component {
  onSubmit = ({ email }) => {
    SessionAPI.forgot_password({ email });
  };

  render() {
    const fields = [
      {
        name: 'email',
        type: 'email',
        title: 'Email',
        placeholder: 'Email'
      }
    ];

    return (
      <AuthLayout>
        <div class="page">
          <Helmet>
            <title>Forgot password</title>
          </Helmet>
          <div class="title">
            <h1>Forgot password</h1>
          </div>
          <div class="login no-center">
            <Form
              fields={fields}
              submitTitle={'Send reset email'}
              onSubmit={this.onSubmit}
            />
          </div>
        </div>
      </AuthLayout>
    );
  }
}

export default ForgotPassword;
