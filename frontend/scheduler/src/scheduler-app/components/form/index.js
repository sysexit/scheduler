import clsx from 'clsx';
import React from 'react';
import { Button, Row, Col, Alert } from 'reactstrap';
import FormInput from './input';

const Form = ({ children }) => {
  return children({
    FormFields,
    FormError,
    FormField,
    FormButton,
    FormRow,
    FormFooter,
  });
}

const FormFields = ({ fields }) => {
  return fields.map((field) => {
    if (Array.isArray(field)) {
      return <FormRow field={field} />;
    } else {
      return (
        <div className="form-group">
          <FormField {...field}>
            <FormInput {...field} />
          </FormField>
        </div>
      );
    }
  });
}

const FormError = ({ error }) => {
  return error ? <Alert color="danger">{error}</Alert> : null;
};

export const FormField = ({ name, title, children, className }) => (
  <>
    {title && (
      <label className={className} id={`${name}-label`}>
        {title}
      </label>
    )}
    {children}
  </>
);

export const FormButton = ({ children, color, onClick, type, submitTitle }) => {
  const title = children || submitTitle || 'Submit';
  return (
    <Button color={color} type={type} onClick={onClick}>
      {title}
    </Button>
  );
};

const FormRow = ({ field: fields }) => (
  <Row form>
    {fields.map((field) => (
      <Col>
        <div className="form-group">
          <FormField {...field}>
            <FormInput {...field} />
          </FormField>
        </div>
      </Col>
    ))}
  </Row>
);

const FormFooter = ({
  submitTitle,
  submitColor = 'primary',
  isModal,
  cancelTitle,
  onCancel,
  additionalButtonsPost,
  additionalButtonsPre,
  values
}) => {
  const AdditionalButtonsPre = additionalButtonsPre;
  const AdditionalButtonsPost = additionalButtonsPost;
  return (
    <div
      className={clsx({ 'form-group': !isModal }, { 'modal-footer': isModal })}
    >
      {additionalButtonsPre && <AdditionalButtonsPre values={values} />}
      {onCancel && <Button onClick={onCancel}>{cancelTitle}</Button>}
      <FormButton color={submitColor}>{submitTitle}</FormButton>
      {additionalButtonsPost && <AdditionalButtonsPost values={values} />}
    </div>
  );
};

export default Form;
