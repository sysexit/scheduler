import React, { Fragment } from 'react';
import { Helmet } from 'react-helmet';
import { connect } from 'react-redux';

import ScheduleHeader from 'scheduler-app/schedule/components/ScheduleHeader';
import ScheduleToolbar from 'scheduler-app/schedule/components/ScheduleToolbar';
import ScheduleFooter from 'scheduler-app/schedule/components/ScheduleFooter';
import ScheduleGrid from 'scheduler-app/schedule/components/ScheduleGrid';
import ScheduleLayout from 'scheduler-app/schedule/components/ScheduleLayout';

import SideBarToggle from 'scheduler-app/components/layout/SideBarToggle';
import ModalRoot from 'scheduler-app/components/ModalRoot';

import { loadSchedule } from 'scheduler-app/schedule/schedule';

import { LOAD_STAFF_TYPE } from 'scheduler-app/lib/constants';
import { GROUP } from 'scheduler-app/lib/permissions';

import { showModal, hideModal } from 'scheduler-app/redux/modal';
import { loadStaff } from 'scheduler-app/redux/staff';
import { loadPositions } from 'scheduler-app/redux/positions';
import { toggleSidebar, updateView } from 'scheduler-app/redux/view';
import { loadTemplates } from 'scheduler-app/redux/templates';

import SideBar from 'scheduler-app/containers/SideBar';
import ScheduleContext from 'scheduler-app/schedule/ScheduleContext';
import {
  getWeekEnd,
  getWeekStart,
  getActiveSchedule,
  getViewStart
} from '../selectors';
import { updateDate, setDate } from 'scheduler-app/redux/view';
import { getScheduleViewStaff } from '../../selectors/staff';

class ScheduleApp extends React.Component {
  componentWillMount() {
    const { group, loadStaff, loadPositions, loadTemplates } = this.props;
    loadPositions();
    loadStaff(LOAD_STAFF_TYPE.SCHEDULE);
    this.loadShifts();

    if (group == GROUP.ADMIN) {
      loadTemplates();
    }
  }

  componentDidUpdate(prevProps) {
    const oldStart = prevProps.start;
    const newStart = this.props.start;
    if (oldStart.toDateString() !== newStart.toDateString()) this.loadShifts();
  }

  loadShifts() {
    const { start, end, loadSchedule } = this.props;

    if (!start || !end) return;

    loadSchedule(start, end);
  }

  render() {
    const {
      // Values
      start,
      end,
      viewStart,
      sideBarOpen,
      day,
      enabledPositions,
      positions,
      schedule,
      staff,
      view,
      group,

      // Functions
      showModal,
      hideModal,
      toggleSidebar,
      updateView,
      updateDate,
      setDate
    } = this.props;

    const context = {
      day,
      start,
      end,
      viewStart,
      view,
      group,
      staff,
      enabledPositions,
      positions,
      schedule,
      // Functions
      showModal,
      hideModal
    };

    return (
      <>
        <Helmet>
          <title>Scheduler</title>
        </Helmet>
        <ScheduleContext.Provider value={context}>
          <ScheduleLayout>
            <SideBar Publish PositionsFilter />
            <div className="col pt-3">
              <SideBarToggle
                toggleSidebar={toggleSidebar}
                sideBarOpen={sideBarOpen}
              />
              <ScheduleToolbar
                updateView={updateView}
                updateDate={updateDate}
                setDate={setDate}
              />
              <div class="table schedule-table col mt-3">
                <ScheduleHeader view={view} start={start} />
                <ScheduleGrid />
                <ScheduleFooter />
              </div>
            </div>
          </ScheduleLayout>
        </ScheduleContext.Provider>
        <ModalRoot hideModal={hideModal} />
      </>
    );
  }
}

// prettier-ignore
export default connect(
  (state) => {
    return {
      start: getWeekStart(state),
      end: getWeekEnd(state),
      viewStart: getViewStart(state),
      day: state.view.date,
      sideBarOpen: state.view.sideBarOpen,
      view: state.view.view,
      group: state.currentUser.group,
      enabledPositions: state.view.filteredPositions,
      staff: getScheduleViewStaff(state),
      positions: state.positions,
      schedule: getActiveSchedule(state),
    };
  },
  (dispatch) => {
    return {
      hideModal: () => dispatch(hideModal()),
      showModal: (modalProps, modalType) => { dispatch(showModal({ modalProps, modalType })) },
      loadSchedule: (start, end) => { dispatch(loadSchedule({ start, end })) },
      loadStaff: (type) => { dispatch(loadStaff({ type })) },
      loadPositions: () => dispatch(loadPositions()),
      toggleSidebar: () => dispatch(toggleSidebar()),
      updateView: (view) => { dispatch(updateView({ view })) },
      setDate: (date) => { dispatch(setDate({ date })) },
      updateDate: (view, type) => { dispatch(updateDate({ view, type })) },
      loadTemplates: () => { dispatch(loadTemplates()) },
    };
  }
)(ScheduleApp)
