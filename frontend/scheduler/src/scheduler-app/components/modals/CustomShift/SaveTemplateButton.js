import React from 'react';
import { FormGroup } from 'reactstrap';

import FormCheckbox from 'scheduler-app/components/form/input/FormCheckbox';
import { FormField } from '../../form';

const SaveTemplate = () => (
  <FormGroup>
    <FormCheckbox name="savetemplate" />
    <FormField
      name="savetemplate"
      title="Save as shift template"
      className="mb-0"
    />
  </FormGroup>
);

export default SaveTemplate;
