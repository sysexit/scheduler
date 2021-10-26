import axios from 'axios';
import authHeader, { logout } from '../utils/helpers';

const api = axios.create({
  baseURL: process.env.API_URL,
  withCredentials: true,
  headers: authHeader()
});

function encodeUrl(url, data) {
  let newUrl = url;
  for (const tag of newUrl.match(/:\w+/g) || []) {
    const paramName = tag.slice(1);
    let value = data[paramName];
    delete data[paramName];
    if (value === undefined) {
      console.warn("Warning: calling", method, "without", tag);
      value = "";
    }
    newUrl = newUrl.replace(tag, value);
  }
  return newUrl;
}

export const GETNEW = (url) => (data, params) => {
  let newUrl = encodeUrl(url, data);
  try {
    const response = api.get(newUrl, {
      params: params
    });
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const POSTNEW = (url) => (data, params) => {
  let newUrl = encodeUrl(url, data);
  try {
    const response = api.post(newUrl, params);
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const PUTNEW = (url) => (data, params) => {
  let newUrl = encodeUrl(url, data);
  try {
    const response = api.put(newUrl, params);
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const DELETENEW = (url) => (data, params) => {
  let newUrl = encodeUrl(url, data);
  try {
    const response = api.delete(newUrl, {
      data: params
    });
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const GET = (url) => (params) => {
  try {
    const response = api.get(url, {
      params: params
    }).catch(err => {
      var invalid = err.response.headers['www-authenticate'].includes('invalid_token');
      if (invalid)
        logout();
    });
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const POST = (url) => (data) => {
  try {
    const response = api.post(url, data);
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const PUT = (url) => (data) => {
  try {
    const response = api.put(url, data);
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const DELETE = (url) => (data) => {
  try {
    const response = api.delete(url, {
      data: data
    });
    return response;
  } catch (error) {
    console.error(error);
  }
};
