import * as types from "./mutation-types";
import router from "@/router/index.js";

export const submit = ({ state, commit }) => {
  if (isEmpty(state.personal) || isEmpty(state.bank) || isEmpty(state.password)) {
    console.log("is empty");
    return;
  }
  let data = {
    info: {
      personal: state.personal,
      bank: state.bank,
      superann: state.super,
    },
    password: state.password,
    token: router.currentRoute._value.params.token,
  };
  return new Promise((reject) => {
    window.axios
      .post("/onboarding", data)
      .then(() => {
        window.location = "https://staff.domain.com";
      })
      .catch((err) => {
        commit(types.SUBMIT_ERROR, err.response.data.error.message);
        reject(err);
      });
  });
};

export const savePersonal = ({ commit }, data) => {
  commit(types.SAVE_PERSONAL, data);
};

export const saveBank = ({ commit }, data) => {
  commit(types.SAVE_BANK, data);
};

export const saveSuper = ({ commit }, data) => {
  commit(types.SAVE_SUPER, data);
};

export const saveAll = ({ state, commit }) => {
  commit(types.SUBMIT);
  if (isEmpty(state.personal) || isEmpty(state.bank)) {
    commit(types.SUBMIT_ERROR, "Form incomplete or contains errors.");
    return;
  }
  router.push("password");
};

export const savePassword = ({ commit }, data) => {
  commit(types.SAVE_PASSWORD, data);
};

function isEmpty(obj) {
  return Object.keys(obj).length === 0 && obj.constructor === Object;
}
