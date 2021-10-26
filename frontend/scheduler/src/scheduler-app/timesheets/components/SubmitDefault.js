import React from 'react';
import { Button, ButtonGroup } from 'reactstrap';

export default class SubmitDefaultButton extends React.Component {
  submit = () => {
    const { start, end, user, submitDefault } = this.props;
    submitDefault(user, start, end);
  }

  render() {
    return (
      <ButtonGroup>
        <Button color="primary" onClick={this.submit}>
          Fill Defaults
        </Button>
      </ButtonGroup>
    )
  }
}