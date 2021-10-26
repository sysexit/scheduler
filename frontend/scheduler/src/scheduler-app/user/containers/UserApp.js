import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Helmet } from 'react-helmet';

import UserLayout from '../components/UserLayout';
import UserPassword from '../components/UserPassword';
import UserDetails from '../components/UserDetails';
import { updateUserDetails, updateUserPassword } from '../user';

class UserApp extends Component {
  render() {
    const { tab } = this.props;

    return (
      <UserLayout>
        <Helmet>
          <title>User settings</title>
        </Helmet>
        {tab == 'details' ? (
          <>
            <div class="title">
              <h1>User settings</h1>
            </div>
            <UserDetails {...this.props} />
          </>
        ) : tab == 'password' ? (
          <>
            <div class="title">
              <h1>Update password</h1>
            </div>
            <UserPassword {...this.props} />
          </>
        ) : null}
      </UserLayout>
    );
  }
}

export default connect(
  (state) => {
    return {
      tab: state.user.tab,
      user: state.currentUser
    };
  },
  {
    updateUserDetails,
    updateUserPassword
  }
)(UserApp);
