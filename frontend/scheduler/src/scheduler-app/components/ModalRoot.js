import React from 'react';
import { connect } from 'react-redux';
import { Modal } from 'reactstrap';

import { default as modalTypes } from './modals';

const MODAL_TYPES = {
  CustomShift: modalTypes.CustomShift,
  ShiftFromTemplate: modalTypes.ShiftFromTemplate,
  StaffModification: modalTypes.StaffModification,
  PositionModification: modalTypes.PositionModification
};

class ModalContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      modalIsOpen: props.modalProps.open
    };
  }

  componentWillReceiveProps(nextProps) {
    if (!nextProps.modalProps) return;
    if (nextProps.modalProps.open !== this.props.modalProps.open) {
      this.setState({
        modalIsOpen: nextProps.modalProps.open
      });
    }
  }

  closeModal = () => {
    this.props.hideModal();
  };

  render() {
    if (!this.props.modalType) {
      return null;
    }
    const SpecifiedModal = MODAL_TYPES[this.props.modalType];
    return (
      <div>
        <Modal isOpen={this.state.modalIsOpen}>
          <SpecifiedModal
            closeModal={this.closeModal}
            {...this.props.modalProps}
          />
        </Modal>
      </div>
    );
  }
}

export default connect((state) => {
  return {
    ...state.modal
  };
}, null)(ModalContainer);
