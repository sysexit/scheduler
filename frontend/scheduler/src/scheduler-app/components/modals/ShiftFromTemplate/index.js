import React from 'react';
import { connect } from 'react-redux';
import find from 'lodash/find';
import {
  Button,
  ModalBody,
  ModalFooter,
  Label,
  Input,
  FormGroup,
  Form,
  ModalHeader
} from 'reactstrap';

import CreateCustom from './CreateCustom';
import ShiftBlock from './ShiftBlock';
import { DAYS, MONTHS } from 'scheduler-app/lib/constants';

class ShiftFromTemplate extends React.Component {
  render() {
    const userid = this.props.user;
    const { date, staff } = this.props;
    const day = DAYS[date.getDay()];
    const month = MONTHS[date.getMonth()];
    const header = `Create Shift on ${day}, ${date.getDate()} ${month}`;
    const user = find(staff, (s) => s.id == userid);
    const userRoles = user.positions;

    return (
      <div>
        <ModalBody>
          <ModalHeader>{header}</ModalHeader>
          {this.props.templates.map((template) => {
            if (userRoles.includes(template.position))
              return (
                <ShiftBlock
                  userid={this.props.user}
                  date={this.props.date}
                  start={template.start}
                  end={template.end}
                  position={template.position}
                />
              );
          })}
          <CreateCustom {...this.props} />
          <ModalFooter>
            <Button color="primary" onClick={this.props.closeModal}>
              Close
            </Button>
          </ModalFooter>
        </ModalBody>
      </div>
    );
  }
}

export default connect((state) => {
  return {
    templates: state.templates,
    staff: state.staff
  };
}, null)(ShiftFromTemplate);
