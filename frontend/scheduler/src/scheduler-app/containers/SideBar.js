import React, { Component } from 'react';
import { connect } from 'react-redux';

import Publish from 'scheduler-app/components/SideBar/Publish';
import PositionsFilter from 'scheduler-app/components/SideBar/PositionsFilter';
import UserList from 'scheduler-app/components/SideBar/UserList';
import Can from 'scheduler-app/components/Can';

import { loadSchedule, publishSchedule } from 'scheduler-app/schedule/schedule';
import {
  setTimesheetUser,
  loadTimesheets
} from 'scheduler-app/timesheets/timesheets';
import { toggleFilterPosition } from 'scheduler-app/redux/view';
import { getWeekEnd, getWeekStart } from 'scheduler-app/schedule/selectors';

class SideBar extends Component {
  render() {
    // Functions
    const {
      publishSchedule,
      loadSchedule,
      toggleFilterPosition,
      setTimesheetUser,
      loadTimesheets,
    } = this.props;
    // State
    const {
      sideBarOpen,
      view,
      weekStart,
      weekEnd,
      dayDate,
      filteredPositions,
      staff,
      positions,
      timesheetUser,
    } = this.props;

    if (sideBarOpen == false) return null;

    return (
      <div class="sidebar-container">
        <div class="schedule-sidebar">
          {this.props.Publish && (
            <Can
              role={this.props.group}
              perform="sidebar:publish"
              yes={() => (
                <Publish
                  publishSchedule={publishSchedule}
                  loadSchedule={loadSchedule}
                  view={view}
                  weekStart={weekStart}
                  weekEnd={weekEnd}
                  dayDate={dayDate}
                />
              )}
            />
          )}
          {this.props.UserList && (
            <Can
              role={this.props.group}
              perform="sidebar:userlist"
              yes={() => (
                <UserList
                  staff={staff}
                  setTimesheetUser={setTimesheetUser}
                  loadTimesheets={loadTimesheets}
                />
              )}
            />
          )}

          {this.props.PositionsFilter && (
            <PositionsFilter
              staff={staff}
              positions={positions}
              toggleFilterPosition={toggleFilterPosition}
              filteredPositions={filteredPositions}
            />
          )}
        </div>
      </div>
    );
  }
}

export default connect(
  (state) => {
    return {
      sideBarOpen: state.view.sideBarOpen,
      group: state.currentUser.group,
      view: state.view.view,
      weekStart: getWeekStart(state),
      weekEnd: getWeekEnd(state),
      dayDate: state.view.day,
      filteredPositions: state.view.filteredPositions,
      timesheetUser: state.timesheets.timesheetUser,
      staff: state.staff,
      positions: state.positions
    };
  },
  (dispatch) => {
    return {
      publishSchedule: (start, end) => {
        dispatch(publishSchedule({ start, end }));
      },
      loadSchedule: (start, end) => {
        dispatch(loadSchedule({ start, end }));
      },
      toggleFilterPosition: (position, checked) => {
        dispatch(toggleFilterPosition({ position, checked }));
      },
      loadTimesheets: (period_id, user_id) => {
        dispatch(loadTimesheets({ period_id, user_id }));
      },
      setTimesheetUser: (user) => {
        dispatch(setTimesheetUser({ user }));
      }
    };
  }
)(SideBar);
