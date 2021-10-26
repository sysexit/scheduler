import React from 'react';
import { connect } from 'react-redux';
import _ from 'lodash/core';

import Navbar from 'scheduler-app/components/layout/Navbar';
import { loadCurrentUser } from 'scheduler-app/redux/user';
import { getCurrentUser } from 'scheduler-app/utils/helpers';

class App extends React.Component {
  componentWillMount() {
    if (_.isEmpty(this.props.user) && getCurrentUser() !== null)
      this.props.loadCurrentUser();
  }
  render() {
    if (getCurrentUser() !== null && _.isEmpty(this.props.user)) return null;

    return (
      <>
        <Navbar />
        <div class="page">{this.props.children}</div>
      </>
    );
  }
}

export default connect(
  (state) => {
    return {
      user: state.currentUser
    };
  },
  {
    loadCurrentUser
  }
)(App);
