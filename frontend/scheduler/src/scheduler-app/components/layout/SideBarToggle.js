import React from 'react';

const SideBarToggle = ({ sideBarOpen, toggleSidebar }) => {
  return (
    <div onClick={toggleSidebar}>
      {sideBarOpen ? (
        <i class="fa fa-arrow-left"></i>
      ) : (
        <i class="fa fa-arrow-right"></i>
      )}
    </div>
  );
}

export default SideBarToggle;
