import React from 'react';

import Position from './Position';

class PositionFilter extends React.Component {
  render() {
    const { toggleFilterPosition, positions, filteredPositions } = this.props;

    return (
      <div class="sidebar-item is-open" id="sidebar-positions">
        <div class="row no-gutters">
          <div class="col">
            <div class="sidebar-collapse">
              <h6>Positions</h6>
              <ul class="items-container">
                {positions.map((position) => {
                  let checked = filteredPositions.includes(position.id);

                  return (
                    <Position
                      position={position.title}
                      id={position.id}
                      handleClick={toggleFilterPosition}
                      checked={checked}
                    />
                  );
                })}
              </ul>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default PositionFilter;
