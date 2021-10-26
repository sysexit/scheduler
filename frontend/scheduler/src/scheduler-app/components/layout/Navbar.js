import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';

import { getCurrentUser } from 'scheduler-app/utils/helpers';
import { showModal, hideModal } from 'scheduler-app/redux/modal';
import Can from '../Can';
import { Link } from 'react-router-dom';
import {
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  UncontrolledButtonDropdown
} from 'reactstrap';

class Navbar extends Component {
  getDisplayName() {
    const { id, first, display } = this.props;
    if (id == null) {
      return 'Invalid';
    }
    return display ? display : first;
  }

  render() {
    const { group } = this.props;
    const user = getCurrentUser();
    const displayName = this.getDisplayName();

    return (
      <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarToggler"
          aria-controls="navbarToggler"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarToggler">
          <ul class="menu navbar-nav mr-auto mt-2 mt-lg-0">
            {!user && (
              <li>
                <Link to="/login">Login</Link>
              </li>
            )}
            {user && (
              <Fragment>
                <li>
                  <Link to="/schedule">schedule</Link>
                </li>
                <li>
                  <Link to="/timesheets">Timesheets</Link>
                </li>
              </Fragment>
            )}
          </ul>
          {user && (
            <Fragment>
              <Can
                role={group}
                perform="schedule:hours-total"
                yes={() => <Link to="admin">Admin</Link>}
              />

              <UncontrolledButtonDropdown>
                <p
                  class="navbar-text navbar-right nav-link dropdown-toggle"
                  data-toggle="dropdown"
                  data-display="static"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  {displayName}
                </p>
                <DropdownMenu className="dropdown-menu-lg-right">
                  <DropdownItem href="/user">Settings</DropdownItem>
                  <DropdownItem href="/logout">Logout</DropdownItem>
                </DropdownMenu>
              </UncontrolledButtonDropdown>
            </Fragment>
          )}
        </div>
      </nav>
    );
  }
}

export default connect(
  (state) => {
    return {
      ...state.currentUser
    };
  },
  (dispatch) => {
    return {
      showModal: (modalProps, modalType) => {
        dispatch(showModal({ modalProps, modalType }));
      },
      hideModal: () => dispatch(hideModal())
    };
  }
)(Navbar);
