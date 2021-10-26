export const startOf = (date) => {
  return setTime(date, 0, 0, 0);
};

export const endOf = (date) => {
  return setTime(date, 23, 59, 59);
};

export const setTime = (date, hours, minutes, seconds) => {
  let newDate = new Date(date);
  newDate.setHours(hours);
  newDate.setMinutes(minutes);
  newDate.setSeconds(seconds);
  return newDate;
};
