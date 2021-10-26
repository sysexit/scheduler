import decode from 'jwt-decode';
import _ from 'lodash/core';

export function InvalidInput(message) {
  this.message = message;
  this.name = 'InvalidInput';
}

export function timeToDate(time, date) {
  let dateString = new Date(date);
  let split_value = time.split(':');
  let hours = parseInt(split_value[0]);
  let minutes = parseInt(split_value[1]);

  dateString.setHours(hours);
  dateString.setMinutes(minutes);
  dateString.setSeconds(0);

  return dateString.toISOString();
}

export function formatDatetime(date) {
  let days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thur', 'Fri', 'Sat'];
  let months = [
    'Jan',
    'Feb',
    'Mar',
    'Apr',
    'May',
    'June',
    'July',
    'Aug',
    'Sep',
    'Oct',
    'Nov',
    'Dec'
  ];
  const day = days[date.getDay()];
  const month = months[date.getMonth()];
  return `${day}, ${date.getDate()} ${month}`;
}

export function getPosition(id, positionList) {
  return positionList.filter((position) => position.id == id)[0].title;
}

// /(\d+)(?::(\d\d))?\s*(p?)/
// /(\d+)(?::|[\.])?(\d\d)?\s*(p?)/
export function parseTime(t, date) {
  var d = new Date(date);
  var time = t.match(/(\d+)(?::|[\.])?(\d\d)?\s*(p?)/);
  let hour = parseInt(time[1]);
  // TODO: Rewrite this
  const isPM = time[3] == 'p';
  if (hour == 12 && !isPM) hour = 0;
  else if (isPM && hour != 12) hour += 12;

  if (hour < 5 || hour > 22) throw new InvalidInput('Invalid input');

  d.setHours(hour);
  d.setMinutes(parseInt(time[2]) || 0);
  d.setSeconds(0);
  return d;
}

export function get12Hours(hours) {
  if (hours == 12 || hours == 24) return hours;
  return hours % 12;
}

export function getHourText(date_string) {
  let date = new Date(date_string);
  let minutes = date.getMinutes() == 0 ? '' : ':' + date.getMinutes();
  let hours = get12Hours(date.getHours());
  let result = hours + minutes;

  if (date.getHours() < 12) result += 'a';
  else result += 'p';

  return result;
}

// Summarize all period lengths from a list of shifts
export function shiftsSum(shifts) {
  if (shifts == null) return null;
  let total = 0;
  shifts.forEach((shift) => {
    const start = new Date(shift.start);
    const end = new Date(shift.end);

    total += (end - start) / 1000 / 60 / 60;
  });

  return total;
}

export function getMonday(d) {
  d = new Date(d);
  var day = d.getDay();
  var diff = d.getDate() - day + (day == 0 ? -6 : 1); // adjust when day is sunday
  d = new Date(d.setDate(diff));
  d.setHours(0);
  d.setMinutes(0);
  d.setSeconds(0);
  return d;
}

export function getSunday(d) {
  var day = getMonday(d);
  day.setDate(day.getDate() + 6);
  day.setHours(23);
  day.setMinutes(59);
  day.setSeconds(59);
  return day;
}

export function logout() {
  localStorage.removeItem('auth_token');
  document.cookie =
    `Authorization=; domain=.${process.env.DOMAIN}; path=/; expires=Thu, 01 Jan 1970 00:00:00 UTC`;
  window.location = '/login';
}

export function authCookie() {
  const cookiez = document.cookie.split(';').map((cookie) => {
    const list = cookie.split('=');
    return { name: list[0], value: list[1] };
  });
  return _.find(cookiez, (cookie) => cookie.name == 'Authorization');
}

export function getCurrentUser() {
  try {
    const token = decode(authCookie().value);
    const time = new Date().getTime() / 1000;
    if (time > token.exp) {
      logout();
      return null;
    } else return token;
  } catch (err) {
    return null;
  }
}

export default function authHeader() {
  const auth_token = authCookie();

  if (auth_token && auth_token.value) {
    return { Authorization: ' Bearer ' + auth_token.value };
  } else {
    return {};
  }
}

export function getParam(location, param) {
  const { search } = location;
  const params = new URLSearchParams(search);
  if (!params.has(param)) window.location = '/login';
  return params.get(param);
}
