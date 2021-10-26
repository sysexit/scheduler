import React from 'react';
import { Button, ButtonGroup } from 'reactstrap';
import { UPDATE_TYPE } from '../../../redux/view';

class ViewDateUpdate extends React.Component {
  next = () => {
    const { view, updateDate } = this.props;
    updateDate(view, UPDATE_TYPE.INCREASE);
  };

  previous = () => {
    const { view, updateDate } = this.props;
    updateDate(view, UPDATE_TYPE.DECREASE);
  };

  today = () => {
    this.props.setDate(new Date());
  };

  render() {
    return (
      <ButtonGroup className="mr-2">
        <Button onClick={this.previous}>
          <div>
            <i class="fa fa-angle-left"></i>
          </div>
        </Button>
        <Button onClick={this.today}>
          <div>
            <i class="fa fa-calendar"></i>
          </div>
        </Button>
        <Button onClick={this.next}>
          <div>
            <i class="fa fa-angle-right"></i>
          </div>
        </Button>
      </ButtonGroup>
    );
  }
}

export default ViewDateUpdate;
