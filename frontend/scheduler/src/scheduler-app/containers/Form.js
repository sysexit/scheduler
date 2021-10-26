import React, { Component } from 'react';
import { Form as FinalForm } from 'react-final-form';

import Form from '../components/form';

export default class FormContainer extends Component {
  render() {
    const { fields, onSubmit, initialValues } = this.props;
    return (
      <FinalForm
        onSubmit={onSubmit}
        initialValues={initialValues}
        render={({ handleSubmit, submitError, values }) => (
          <Form>
            {({ FormFields, FormError, FormField, FormButton, FormRow, FormFooter }) => (
              <form onSubmit={handleSubmit}>
                <FormError error={submitError} />
                <FormFields fields={fields} />
                <FormFooter {...this.props} values={values} />
              </form>
            )}
          </Form>
        )}
      />
    );
  }
}