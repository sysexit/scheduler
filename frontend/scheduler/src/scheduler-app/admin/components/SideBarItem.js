import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'reactstrap';

const SideBarItem = ({ title, path }) => (
  <Link to={path} className="mb-1">
    <Button color="primary">{title}</Button>
  </Link>
);

export default SideBarItem;
