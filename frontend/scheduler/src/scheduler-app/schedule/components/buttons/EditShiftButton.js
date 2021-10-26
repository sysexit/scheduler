import React from 'react';

class EditShiftButton extends React.Component {
  onClick = () => {
    this.props.handleClick(this.props.data);
  };

  render() {
    return (
      <div className="col edit-shift-wrapper" onClick={this.onClick}>
        <button
          className="btn btn-primary edit-shift btn-block btn-sm"
          type="button"
        >
          <div>
            <i className="fa fa-pencil-alt"></i>
          </div>
        </button>
      </div>
    );
  }
}

export default EditShiftButton;
