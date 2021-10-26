export default {
  login: [
    {
      name: 'email',
      type: 'email',
      placeholder: 'Email',
      required: true,
      autoComplete: 'email'
    },
    {
      name: 'password',
      type: 'password',
      placeholder: 'Password',
      required: true,
      autoComplete: 'password'
    }
  ],
  forgotPassword: [
    {
      name: 'email',
      type: 'email',
      title: 'Email',
      placeholder: 'Email',
      required: true,
    }
  ],
  shift: [
    {
      name: 'user',
      type: 'select',
      title: 'Assign to',
      required: true,
      options: []
    },
    {
      name: 'start',
      type: 'time',
      title: 'Start time',
      required: true,
      min: '05:00',
      max: '23:00'
    },
    {
      name: 'end',
      type: 'time',
      title: 'End time',
      required: true,
      min: '05:00',
      max: '23:00'
    },
    {
      name: 'position',
      type: 'select',
      title: 'Position',
      required: true,
      options: [
        {
          name: 'Select a position',
          value: ''
        }
      ]
    }
  ],
  staffmanage: [
    {
      name: 'display',
      type: 'text',
      title: 'Display name',
      placeholder: 'Display name'
    },
    [
      {
        name: 'first',
        type: 'text',
        title: 'First Name',
        required: true,
        placeholder: 'First Name'
      },
      {
        name: 'last',
        type: 'text',
        title: 'Last Name',
        required: true,
        placeholder: 'Last Name'
      }
    ]
  ]
};
