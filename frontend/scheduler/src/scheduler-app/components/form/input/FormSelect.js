import React from 'react';
import { Field } from 'react-final-form';

const FormInput = ({
  name,
  placeholder,
  required,
  readOnly,
  autoComplete,
  options,
  multiple
}) => (
  <Field
    className="form-control"
    type="select"
    placeholder={placeholder}
    aria-labelledby={`${name}-label`}
    readOnly={readOnly}
    autoComplete={autoComplete}
    multiple={multiple}
    required={required}
    // Final form
    name={name}
    component="select"
  >
    {options.map(({ name, value }) => (
      <option value={value}>{name}</option>
    ))}
  </Field>
);

export default FormInput;
