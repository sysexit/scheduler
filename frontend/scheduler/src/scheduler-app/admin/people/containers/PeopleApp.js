import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Helmet } from 'react-helmet';
import { Button } from 'reactstrap';
import sortBy from 'lodash/sortBy';

import ModalRoot from 'scheduler-app/components/ModalRoot';
import { showModal, hideModal } from 'scheduler-app/redux/modal';
import { loadStaff } from 'scheduler-app/redux/staff';
import { LOAD_STAFF_TYPE } from 'scheduler-app/lib/constants';
import UserTable from '../../components/UserTable';
import { loadPositions } from 'scheduler-app/redux/positions';
import AdminContainer from '../../components/AdminContainer';

class PeopleApp extends Component {
  componentWillMount() {
    this.props.loadStaff(LOAD_STAFF_TYPE.ALL);
    this.props.loadPositions();
  }

  editUser = (e, user) => {
    const { showModal, hideModal } = this.props;
    const data = {
      open: true,
      hideModal,
      user
    };

    showModal(data, 'StaffModification');
  };

  render() {
    const users = sortBy(this.props.users, ['id']);

    return (
      <>
        <AdminContainer>
          <Helmet>
            <title>Users</title>
          </Helmet>
          <div>
            <Button color="primary" onClick={this.editUser}>
              Add person
            </Button>
          </div>
          <div>
            <UserTable users={users}>
              {({ user }) => (
                <td className="text-right">
                  <Button onClick={(e) => this.editUser(e, user)}>
                    Edit user
                  </Button>
                </td>
              )}
            </UserTable>
          </div>
        </AdminContainer>
        <ModalRoot hideModal={hideModal} />
      </>
    );
  }
}

export default connect(
  (state) => {
    return {
      users: state.staff
    };
  },
  (dispatch) => {
    return {
      loadStaff: (type) => {
        dispatch(loadStaff({ type }));
      },
      hideModal: () => dispatch(hideModal()),
      showModal: (modalProps, modalType) => {
        dispatch(showModal({ modalProps, modalType }));
      },
      loadPositions: () => dispatch(loadPositions())
    };
  }
)(PeopleApp);
