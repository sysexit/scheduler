import React from 'react';
import { connect } from 'react-redux';
import { Helmet } from 'react-helmet';

import Form from 'scheduler-app/containers/Form';
import fields from 'scheduler-app/components/form/fields';
import { login } from 'scheduler-app/auth/auth.js';
import AuthLayout from '../components/AuthLayout';
// import { FORM_ERROR } from 'final-form'

class LoginApp extends React.Component {
  state = {};

  onSubmit = async (credentials) => {
    const { login } = this.props;
    await login(credentials);
    // return { [FORM_ERROR]: 'Login Failed' }
  };

  render() {
    return (
      <AuthLayout>
        <Helmet>
          <title>Login</title>
        </Helmet>
        <div class="title">
          <h1>Login</h1>
        </div>
        <div class="login no-center">
          <Form
            fields={fields.login}
            submitTitle={'Login'}
            onSubmit={this.onSubmit}
          />
          <div>
            <div>
              <a href="/forgotpassword">Forgot password?</a>
            </div>
          </div>
        </div>
      </AuthLayout>
    );
  }
}

export default connect(null, { login })(LoginApp);
