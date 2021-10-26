import React from 'react';

class ColAddShift extends React.Component {
  onClick = () => {
    this.props.handleClick(this.props.value);
  };

  render() {
    return (
      <div
        class="col-3 align-self-end add-shift-wrapper"
        onClick={this.onClick}
      >
        <div class="add-shift">
          <i class="fa fa-plus"></i>
        </div>
      </div>
    );
  }
}

export default ColAddShift;
