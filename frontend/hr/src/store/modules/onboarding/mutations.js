import * as types from "./mutation-types";

export default {
  [types.SAVE_PERSONAL](state, data) {
    state.personal = data;
    state.personal.zip = parseInt(data.zip);
  },

  [types.SAVE_BANK](state, data) {
    state.bank = data;
    state.bank.bsb = parseInt(data.bsb);
    state.bank.number = parseInt(data.number);
    state.bank.tfn = parseInt(data.tfn);
  },

  [types.SAVE_SUPER](state, data) {
    state.super = data;
    state.super.usi = parseInt(data.usi);
    state.super.number = parseInt(data.number);
  },

  [types.SAVE_PASSWORD](state, data) {
    state.password = data;
  },

  [types.SUBMIT](state) {
    state.error = null;
  },

  [types.SUBMIT_ERROR](state, errorResponse) {
    state.error = errorResponse;
  },
};
