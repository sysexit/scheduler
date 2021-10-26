import React, { Component, Fragment } from 'react';
import { Helmet } from 'react-helmet';
import { connect } from 'react-redux';
import r from 'lodash/round';
import _ from 'lodash/core';

import TimesheetContext from 'scheduler-app/timesheets/TimesheetContext';
import TimesheetsLayout from 'scheduler-app/timesheets/components/TimesheetsLayout';
import TimesheetsSummary from 'scheduler-app/timesheets/components/TimesheetsSummary';
import TimesheetsHeader from 'scheduler-app/timesheets/components/TimesheetsHeader';
import TimesheetGrid from 'scheduler-app/timesheets/components/TimesheetGrid';
import TimesheetsFooter from 'scheduler-app/timesheets/components/TimesheetsFooter';
import SubmitDefaultButton from 'scheduler-app/timesheets/components/SubmitDefault';

import { total, totalByDay } from 'scheduler-app/timesheets/selectors';
import { getUserSchedule } from 'scheduler-app/schedule/selectors';

import ViewDateUpdate from 'scheduler-app/schedule/components/buttons/ViewDateUpdate';
import SideBarToggle from 'scheduler-app/components/layout/SideBarToggle';
import Can from 'scheduler-app/components/Can';

import SideBar from 'scheduler-app/containers/SideBar';

import { LOAD_STAFF_TYPE } from 'scheduler-app/lib/constants';

import { getWeekEnd, getWeekStart } from 'scheduler-app/schedule/selectors';

import {
  loadTimesheets,
  setTimesheetUser,
  submitTimesheet,
  submitDefault,
  updateTimesheet,
  deleteTimesheet
} from 'scheduler-app/timesheets/timesheets';
import { loadSchedule } from 'scheduler-app/schedule/schedule';
import { loadStaff } from 'scheduler-app/redux/staff';
import { toggleSidebar, updateDate, setDate } from 'scheduler-app/redux/view';

class Timesheets extends Component {
  componentWillMount() {
    const { start, end, loadStaff, loadSchedule } = this.props;
    loadStaff(LOAD_STAFF_TYPE.SCHEDULE);
    loadSchedule(start, end);
  }

  componentWillReceiveProps(nextProps) {
    const oldUser = this.props.timesheetUser;
    const newUser = nextProps.timesheetUser;

    const oldStart = this.props.start;
    const newStart = nextProps.start;
    const newEnd = nextProps.end;

    if (oldStart.toDateString() !== newStart.toDateString()) {
      this.props.loadTimesheets(oldUser, newStart);
      this.props.loadSchedule(newStart, newEnd);
    }

    if ((oldUser !== newUser) && newUser) {
      this.props.loadTimesheets(newUser, oldStart);
    }
  }

  componentWillUnmount() {
    const { setTimesheetUser } = this.props;

    setTimesheetUser(null);
  }

  loadUser() {
    const { setTimesheetUser, user } = this.props;
    const { id } = user;

    setTimesheetUser(id);
  }

  renderHeader() {
    const { timesheetUser, staff, start, end, view, updateDate, setDate, submitDefault } = this.props;
    if (!staff) return null;

    const result = staff.filter((member) => member.id == timesheetUser);

    if (result.length == 0) return null;
    const user = result[0];

    return (
      <div class="row justify-content-between">
        <div class="col-auto title-bar">
          {user.first} {user.last}
        </div>
        <div className="col-auto" style={{ display: 'flex' }}>
          <div>
            <SubmitDefaultButton
              submitDefault={submitDefault}
              user={user.id}
              start={start}
              end={end}
            />
          </div>
          <div class="col-auto">
            <ViewDateUpdate
              view={view}
              updateDate={updateDate}
              setDate={setDate}
            />
          </div>
        </div>
      </div>
    );
  }

  render() {
    const {
      start,
      end,
      sideBarOpen,
      user,
      timesheetUser,
      userSchedule,
      timesheetsTotal,
      timesheetsTotalByDay,
      scheduledTotal,
      scheduledTotalByDay,

      updateTimesheet,
      submitTimesheet,
      toggleSidebar,
      deleteTimesheet
    } = this.props;
    let timesheets = this.props.timesheets;

    const userShifts = userSchedule;
    const { id, group } = user;

    if (!!id && timesheetUser == null) {
      this.loadUser();
      return null;
    }

    if (
      timesheets &&
      timesheets.length > 0 &&
      timesheets[0].userId !== timesheetUser
    ) {
      timesheets = [];
    }

    const context = {
      updateTimesheet,
      submitTimesheet,
      deleteTimesheet,
      timesheetsTotal,
      timesheetsTotalByDay,
      scheduledTotal,
      scheduledTotalByDay
    };

    return (
      <TimesheetsLayout>
        <Helmet>
          <title>Timesheets</title>
        </Helmet>
        <TimesheetContext.Provider value={context}>
          <Can
            role={group}
            perform="schedule:hours-total"
            yes={() =>
              <SideBar UserList />
            } />
          <div className="col pt-3">
            <Can
              role={group}
              perform="schedule:hours-total"
              yes={() =>
                <SideBarToggle
                  toggleSidebar={toggleSidebar}
                  sideBarOpen={sideBarOpen}
                />}
            />
            {this.renderHeader()}
            <div class="table col mt-3">
              <Can
                role={group}
                perform="schedule:hours-total"
                yes={() => <TimesheetsSummary timesheets={timesheets} />}
              />
              <div>
                <TimesheetsHeader />
                <TimesheetGrid
                  schedule={userShifts}
                  start={start}
                  timesheets={timesheets}
                  userid={timesheetUser}
                />
                <TimesheetsFooter
                  schedule={userShifts}
                  timesheets={timesheets}
                />
              </div>
            </div>
          </div>
        </TimesheetContext.Provider>
      </TimesheetsLayout>
    );
  }
}

// prettier-ignore
export default connect(
  (state) => {
    return {
      sideBarOpen: state.view.sideBarOpen,
      view: state.view.view,
      start: getWeekStart(state),
      end: getWeekEnd(state),
      user: state.currentUser,
      staff: state.staff,
      timesheets: state.timesheets.timesheets,
      timesheetUser: state.timesheets.user,
      userSchedule: getUserSchedule(state),
      timesheetsTotal: r(total(state.timesheets.timesheets, state), 2),
      scheduledTotal: r(total(state.schedule, state), 2),
      timesheetsTotalByDay: totalByDay(state.timesheets.timesheets, state),
      scheduledTotalByDay: totalByDay(state.schedule, state),
    };
  },
  (dispatch) => {
    return {
      loadTimesheets: (user_id, start) => { dispatch(loadTimesheets({ user_id, start })) },
      setTimesheetUser: (user) => { dispatch(setTimesheetUser({ user })) },
      loadSchedule: (start, end) => { dispatch(loadSchedule({ start, end })) },
      loadStaff: (type) => { dispatch(loadStaff({ type })) },
      submitTimesheet: (user_id, timesheet) => { dispatch(submitTimesheet({ user_id, timesheet })) },
      submitDefault: (user_id, start, end) => { dispatch(submitDefault({ user_id, start, end })) },
      deleteTimesheet: (user_id, id) => { dispatch(deleteTimesheet({ user_id, id })) },
      updateTimesheet: (user_id, id, timesheet) => { dispatch(updateTimesheet({ user_id, id, timesheet })) },
      toggleSidebar: () => dispatch(toggleSidebar()),
      setDate: (date) => { dispatch(setDate({ date })) },
      updateDate: (view, type) => { dispatch(updateDate({ view, type })) },
    };
  }
)(Timesheets)
