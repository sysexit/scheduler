import React, { Fragment } from 'react';
import { connect } from 'react-redux';

import { showModal, hideModal } from 'scheduler-app/redux/modal';
import { SHIFT_MODAL_TYPE } from 'scheduler-app/lib/constants';

const mapDispatchToProps = (dispatch) => ({
  hideModal: () => dispatch(hideModal()),
  showModal: (modalProps, modalType) => {
    dispatch(showModal({ modalProps, modalType }));
  }
});

class CreateCustom extends React.Component {
  onClick = () => {
    const { user, date, closeModal } = this.props;

    const data = {
      open: true,
      closeModal: closeModal,
      user: user,
      date,
      type: SHIFT_MODAL_TYPE.ADD
    };

    this.props.closeModal();
    this.props.showModal(data, 'CustomShift');
  };

  render() {
    return (
      <Fragment>
        <hr />
        <div onClick={this.onClick}>
          <div
            class="shift-block-item"
            style={{ backgroundColor: 'darkolivegreen' }}
          >
            <div class="info row">
              <div class="col-auto">
                <span class="time">Create custom shift</span>
              </div>
              <span class="badge-container col-auto"></span>
            </div>
          </div>
        </div>
      </Fragment>
    );
  }
}

export default connect(null, mapDispatchToProps)(CreateCustom);
