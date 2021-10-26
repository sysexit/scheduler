import rules from 'scheduler-app/lib/permissions';

const check = (rules, role, action) => {
  const permissions = rules[role];
  if (!permissions) {
    // role is not present in the rules
    return false;
  }

  if (permissions.includes(action)) {
    return true;
  }
};

const Can = (props) =>
  check(rules, props.role, props.perform) ? props.yes() : props.no();

Can.defaultProps = {
  yes: () => null,
  no: () => null
};

export default Can;
