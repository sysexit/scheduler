import React from 'react';
import { FormGroup } from 'reactstrap';

import { FormButton } from 'scheduler-app/components/form';

class DeleteShift extends React.Component {
  onClick = () => {
    const { values, deleteSchedule, closeModal } = this.props;
    deleteSchedule(values.id);
    closeModal();
  };

  render() {
    return (
      <FormGroup>
        <FormButton color="danger" type="button" onClick={this.onClick}>
          Delete shift
        </FormButton>
      </FormGroup>
    );
  }
}

export default DeleteShift;
