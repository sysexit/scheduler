import React from 'react';
import { Field } from 'react-final-form';

const FormInput = ({
  name,
  type = 'text',
  className = 'form-control',
  placeholder,
  required,
  readOnly,
  autoComplete
}) => (
  <Field
    className={className}
    type={type}
    placeholder={placeholder}
    aria-labelledby={`${name}-label`}
    required={required}
    readOnly={readOnly}
    autoComplete={autoComplete}
    // Final form
    name={name}
    component="input"
  />
);

export default FormInput;
