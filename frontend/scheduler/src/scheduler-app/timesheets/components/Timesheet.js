import React from 'react';
import r from 'lodash/round';

import {
  parseTime,
  getHourText,
  InvalidInput
} from 'scheduler-app/utils/helpers';
import TimesheetContext from 'scheduler-app/timesheets/TimesheetContext';

export default class Timesheets extends React.Component {
  static contextType = TimesheetContext;

  state = {};

  componentDidMount() {
    const { timesheet } = this.props;
    if (!timesheet) return null;
    const { start, end } = timesheet;
    if (!start || !end) return null;

    let start_text = getHourText(start);
    let end_text = getHourText(end);
    this.setState({
      start: start_text,
      end: end_text
    });
  }

  onChange = (e) => {
    const target = e.target;
    const name = target.name;
    const value = target.value;

    this.setState({
      [name]: value
    });
  };

  hasChanged(startDate, endDate) {
    const { timesheet } = this.props;
    if (!timesheet) return true;
    let { start, end } = timesheet;
    if (!start || !end) return true;

    start = new Date(start).getTime();
    end = new Date(end).getTime();

    return startDate !== start || endDate !== end;
  }

  delete = () => {
    const { start, end } = this.state;
    const { userid, timesheet } = this.props;
    const { deleteTimesheet } = this.context;
    if (!timesheet) return;
    if (start == '' && end == '') {
      deleteTimesheet(userid, timesheet.id);
    }
  };

  onBlur = (e) => {
    const { updateTimesheet, submitTimesheet } = this.context;
    const { date } = this.props;
    const { name } = e.target;
    const value = this.state[name];

    this.delete();

    if (!value) return;

    try {
      let time = parseTime(value, date);
      let hrTime = getHourText(time);
      this.setState({ [name]: hrTime });

      // Submit timesheet
      const { userid } = this.props;
      const { start, end } = this.state;
      if (!start || !end) return;

      const startDate = parseTime(start, date);
      const endDate = parseTime(end, date);

      if (!this.hasChanged(startDate.getTime(), endDate.getTime())) return;

      const timesheet = {
        ...this.props.timesheet,
        user_id: userid,
        start: startDate,
        end: endDate
      };

      // No ID, so submit new timehseet
      if (timesheet.id == undefined) submitTimesheet(userid, { start: startDate, end: endDate });
      else updateTimesheet(userid, timesheet.id, timesheet);
    } catch (error) {
      if (error instanceof InvalidInput)
        this.setState({ [name]: error.message });
    }
  };

  timesheetTotal() {
    const { timesheet } = this.props;
    if (!timesheet) return null;
    const { start, end } = timesheet;
    if (!start || !end) return null;

    const startDate = new Date(start);
    const endDate = new Date(end);
    return r((endDate - startDate) / 1000 / 60 / 60, 2);
  }

  render() {
    return (
      <div class="subrow">
        <div class="subrow-item">
          <input
            type="text"
            name="start"
            value={this.state.start}
            onBlur={(e) => this.onBlur(e)}
            onChange={this.onChange}
          ></input>
        </div>
        <div class="subrow-item">
          <input
            type="text"
            name="end"
            value={this.state.end}
            onBlur={(e) => this.onBlur(e)}
            onChange={this.onChange}
          ></input>
        </div>
        <div class="subrow-item">{this.timesheetTotal()}</div>
      </div>
    );
  }
}
