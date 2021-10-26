const rules = {
  1: ['schedule:view'],
  0: [
    'schedule:modify',
    'schedule:hours-total',
    'sidebar:userlist',
    'sidebar:publish',
    'admin:add-user'
  ]
};

export const GROUP = {
  ADMIN: 0,
  STAFF: 1
};

export default rules;
