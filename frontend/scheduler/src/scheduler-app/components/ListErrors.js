import React from 'react';

const ListErrors = (props) => {
  const { errors } = props;
  return (
    <div>
      {errors.map((error) => (
        <div>{error}</div>
      ))}
    </div>
  );
};

export const ListError = (props) => {
  const { error } = props;
  return <div>{<div>{error}</div>}</div>;
};

export default ListErrors;
