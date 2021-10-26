import React from 'react';
import FormInput from './FormInput';

const FormCheckbox = ({ name, readOnly, autoComplete }) => (
  <FormInput
    name={name}
    type="checkbox"
    className="form-check-input"
    readOnly={readOnly}
    autoComplete={autoComplete}
  />
);

export default FormCheckbox;
