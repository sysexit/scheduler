import React from 'react';
import FormInput from './FormInput';
import FormSelect from './FormSelect';

const INPUTS = {
  text: FormInput,
  password: FormInput,
  email: FormInput,
  time: FormInput,
  select: FormSelect
};

const InputType = ({ type, ...props }) => {
  // const Input = (typeof type === "string" ? INPUTS[type] : type) || FormInput;
  const Input = INPUTS[type] || FormInput;
  return <Input type={type} {...props} />;
};

export default InputType;
