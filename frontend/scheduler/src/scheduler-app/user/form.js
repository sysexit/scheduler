export const PASSWORD_FIELDS = [
  {
    title: 'New password',
    name: 'new_password',
    type: 'password',
    placeholder: 'New password'
  },
  {
    title: 'Confirm new password',
    name: 'confirm_password',
    type: 'password',
    placeholder: 'Confirm new password'
  }
];

export default {
  details: [
    {
      title: 'Email',
      name: 'email',
      type: 'email',
      placeholder: 'Email',
      autoComplete: 'email',
      readOnly: true
      // validate: validate.required(),
    },
    {
      title: 'First Name',
      name: 'first',
      type: 'text',
      placeholder: 'First Name'
    },
    {
      title: 'Last Name',
      name: 'last',
      type: 'text',
      placeholder: 'Last Name'
    }
  ],
  password: [
    {
      title: 'Current password',
      name: 'password',
      type: 'password',
      placeholder: 'Current password',
      autoComplete: 'password'
      // validate: validate.required(),
    },
    ...PASSWORD_FIELDS
  ]
};
