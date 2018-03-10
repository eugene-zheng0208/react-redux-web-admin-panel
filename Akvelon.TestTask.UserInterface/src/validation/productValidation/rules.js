import * as ErrorMessages from './errorMessages.js';

export const required = (text) => {
  if (text) {
    return null;
  } else {
    return ErrorMessages.isRequired;
  }
};

export const minLength = (length) => {
  return (text) => {
    return text.length >= length ? null : ErrorMessages.minLength(length);
  };
};

export const maxLength = (length) => {
  return (text) => {
    return text.length <= length ? null : ErrorMessages.maxLength(length);
  };
};