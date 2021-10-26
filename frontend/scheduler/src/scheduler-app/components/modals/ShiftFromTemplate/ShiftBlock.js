import React from 'react';
import { connect } from 'react-redux';
import { Badge } from 'reactstrap';

import { addSchedule } from 'scheduler-app/schedule/schedule';
import { timeToDate } from 'scheduler-app/utils/helpers';
import { showModal, hideModal } from 'scheduler-app/redux/modal';
import { SHIFT_MODAL_TYPE } from 'scheduler-app/lib/constants';
import { getPosition } from 'scheduler-app/utils/helpers';

class ShiftBlock extends React.Component {
  state = {};

  addTemplateClick = () => {
    const { userid, position, date } = this.props;
    const { addSchedule, hideModal } = this.props;

    const start = timeToDate(this.props.start, date);
    const end = timeToDate(this.props.end, date);

    const data = {
      userid,
      start,
      end,
      position
    };
    addSchedule(data);
    hideModal();
  };

  templateEdit = () => {
    const { userid, date, start, end, position } = this.props;
    const { hideModal, showModal } = this.props;

    const data = {
      open: true,
      hideModal,
      user: userid,
      type: SHIFT_MODAL_TYPE.ADD,
      date,
      shift: {
        start,
        end,
        position
      }
    };

    hideModal();
    showModal(data, 'CustomShift');
  };

  render() {
    const { position, positions } = this.props;
    const positionName = getPosition(position, positions);

    return (
      <div class="shift-block-item">
        <div class="info row" onClick={this.addTemplateClick}>
          <div class="col-auto">
            {this.state.time && <span class="time">{this.state.time}</span>}
            <span class="time">
              {this.props.start} - {this.props.end}
            </span>
          </div>
          <div class="col text-truncate flex-shrink">
            <Badge color="secondary" class="tag position">
              {positionName}
            </Badge>
          </div>
          <span class="badge-container col-auto"></span>
        </div>
        <div class="text-center modify" onClick={this.templateEdit}>
          <i class="icon fa fa-pencil-alt" />
        </div>
      </div>
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
      addSchedule: (shift) => {
        dispatch(addSchedule({ shift }));
      },
      hideModal: () => dispatch(hideModal()),
      showModal: (modalProps, modalType) => {
        dispatch(showModal({ modalProps, modalType }));
      }
    };
  }
)(ShiftBlock);
