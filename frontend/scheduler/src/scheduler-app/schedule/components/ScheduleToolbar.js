import React from 'react';
import {
  UncontrolledButtonDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem
} from 'reactstrap';

import { DAYS, MONTHS } from 'scheduler-app/lib/constants';
import ViewDateUpdate from 'scheduler-app/schedule/components/buttons/ViewDateUpdate';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';

class ScheduleToolbar extends React.Component {
  static contextType = ScheduleContext;

  state = {
    dropdownOpen: false
  };

  updateView = (view) => {
    this.props.updateView(view);
  };

  renderDayViewDate() {
    let date = this.context.day;
    let day = DAYS[date.getDay()];
    let month = MONTHS[date.getMonth()];
    return (
      <div class="title-bar">
        {day}, {month} {date.getDate()} {date.getFullYear()}
      </div>
    );
  }

  renderWeekViewDates() {
    const { start, end } = this.context;
    let startMonth = MONTHS[start.getMonth()];
    let endMonth = MONTHS[end.getMonth()];

    return (
      <div class="title-bar">
        {startMonth} {start.getDate()} - {endMonth} {end.getDate()}
      </div>
    );
  }

  renderDates() {
    switch (this.context.view) {
      case 'Day':
        return this.renderDayViewDate();
      case 'Week':
        return this.renderWeekViewDates();
    }
  }

  render() {
    const { updateDate, setDate } = this.props;
    return (
      <ScheduleContext.Consumer>
        {({ view }) => (
          <div class="row justify-content-between">
            <div class="col-auto">{this.renderDates()}</div>
            <div class="col-auto text-right">
              <ViewDateUpdate
                view={view}
                updateDate={updateDate}
                setDate={setDate}
              />
              <UncontrolledButtonDropdown className="mr-2">
                <DropdownToggle caret>{view}</DropdownToggle>
                <DropdownMenu>
                  <ViewUpdate handleClick={this.updateView} value="Day" />
                  <ViewUpdate handleClick={this.updateView} value="Week" />
                </DropdownMenu>
              </UncontrolledButtonDropdown>
            </div>
          </div>
        )}
      </ScheduleContext.Consumer>
    );
  }
}

class ViewUpdate extends React.Component {
  onClick = () => {
    this.props.handleClick(this.props.value);
  };

  render() {
    return (
      <DropdownItem onClick={this.onClick}>{this.props.value}</DropdownItem>
    );
  }
}

export default ScheduleToolbar;
