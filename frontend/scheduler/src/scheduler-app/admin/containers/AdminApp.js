import React from 'react';
import { Helmet } from 'react-helmet';

import AdminLayout from 'scheduler-app/admin/components/AdminLayout';
import SideBarItem from '../components/SideBarItem';
import SideBar from './SideBar';
import { Outlet } from 'react-router';

const AdminApp = () => (
  <AdminLayout>
    <Helmet>
      <title>Admin</title>
    </Helmet>
    <SideBar>
      <SideBarItem title="Users" path="/admin/people" />
      {/* <SideBarItem title="Positions" path="/admin/positions" /> */}
    </SideBar>
    <Outlet />
  </AdminLayout>
);

export default AdminApp;
