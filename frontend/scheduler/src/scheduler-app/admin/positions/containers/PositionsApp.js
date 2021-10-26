import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Helmet } from 'react-helmet';
import { Button, Table } from 'reactstrap';

import AdminContainer from '../../components/AdminContainer';
import { loadPositions } from 'scheduler-app/redux/positions';
import { showModal, hideModal } from 'scheduler-app/redux/modal';
import ModalRoot from 'scheduler-app/components/ModalRoot';

class PositionsApp extends Component {
  componentWillMount() {
    this.props.loadPositions();
  }

  editPosition = (e, position) => {
    const { showModal, hideModal } = this.props;
    const data = {
      open: true,
      hideModal,
      position
    };

    showModal(data, 'PositionModification');
  };

  render() {
    const { positions } = this.props;

    return (
      <>
        <AdminContainer>
          <Helmet>
            <title>Users</title>
          </Helmet>
          <div>
            <Button color="primary" onClick={this.editPosition}>
              Add position
            </Button>
          </div>
          <div>
            <Table>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Position</th>
                </tr>
              </thead>
              <tbody>
                {positions.map((position) => (
                  <tr>
                    <th scope="row">{position.id}</th>
                    <td>{position.title}</td>
                    <td>
                      <Button onClick={(e) => this.editPosition(e, position)}>
                        Edit position
                      </Button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
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
      positions: state.positions
    };
  },
  (dispatch) => {
    return {
      loadPositions: () => dispatch(loadPositions()),
      hideModal: () => dispatch(hideModal()),
      showModal: (modalProps, modalType) => {
        dispatch(showModal({ modalProps, modalType }));
      }
    };
  }
)(PositionsApp);
