import React from 'react';

const SideBar = ({ children }) => (
  <div class="sidebar-container">
    <div class="sidebar-contents">
      <ul className="menu navbar-nav mr-auto mt-2 mt-lg-0">{children}</ul>
    </div>
  </div>
);

export default SideBar;
