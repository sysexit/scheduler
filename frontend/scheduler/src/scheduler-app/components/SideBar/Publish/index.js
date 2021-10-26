import React from 'react';
import { Button } from 'reactstrap';

class Publish extends React.Component {
  onClick = () => {
    this.props.publishSchedule();
  };

  render() {
    return (
      <div class="sidebar-item is-open" id="sidebar-positions">
        <div class="row no-gutters">
          <div class="col">
            <div class="sidebar-collapse">
              <ul class="items-container">
                <Button color="primary" size="lg" onClick={this.onClick}>
                  Publish
                </Button>
              </ul>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default Publish;
