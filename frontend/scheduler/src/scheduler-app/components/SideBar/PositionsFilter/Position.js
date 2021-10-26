import React from 'react';

class Position extends React.Component {
  onClick = (e) => {
    this.props.handleClick(this.props.id, e.target.checked);
  };

  render() {
    let id = this.props.id;
    return (
      <li class="list-group-item py-1 list-group-item-action border-0 filterable-entity-item">
        <div class="row">
          <div class="pr-1 pl-2 check-entity">
            <div class="custom-control custom-checkbox m-0 ">
              <input
                type="checkbox"
                id={`filterable-Positions-${id}`}
                class="p-0 m-0 custom-control-input entity-checkbox"
                readonly=""
                defaultChecked={this.props.checked}
                onClick={this.onClick}
              />
              <label
                for={`filterable-Positions-${id}`}
                class="custom-control-label"
                style={{ color: 'rgb(204, 204, 204)' }}
              ></label>
            </div>
          </div>
          <div class="col entity-name show-cursor px-0">
            {this.props.position}
          </div>
          <button class="col-1 p-0 pr-3 btn-link edit-entity d-none">
            <i class="fa fa-pencil"></i>
          </button>
        </div>
      </li>
    );
  }
}

export default Position;
