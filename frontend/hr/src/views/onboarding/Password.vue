<template>
  <div class="bg-white min-h-screen flex justify-center items-center">
    <div>
      <Error :message="message" class="mb-5" />
      <form @submit.prevent="onSubmit">
        <div class="shadow overflow-hidden sm:rounded-md">
          <div class="px-4 py-5 bg-white sm:p-6">
            <div class="grid lg:grid-cols-4 gap-6">
              <h1>Set a password</h1>
              <div class="col-span-6">
                <label
                  for="password"
                  class="block text-sm font-medium text-gray-700"
                  >Password</label
                >
                <input
                  type="password"
                  name="password"
                  id="password"
                  autocomplete="password"
                  v-model="v$.form.password.$model"
                  class="
                    mt-1
                    focus:ring-indigo-500 focus:border-indigo-500
                    block
                    w-full
                    shadow-sm
                    sm:text-sm
                    border-gray-300
                    rounded-md
                  "
                />
                <!-- Error Message -->
                <div
                  class="input-errors"
                  v-for="(error, index) of v$.form.password.$errors"
                  :key="index"
                >
                  <div class="error-msg">{{ error.$message }}</div>
                </div>
              </div>

              <div class="col-span-6">
                <label
                  for="confirm_password"
                  class="block text-sm font-medium text-gray-700"
                  >Confirm Password</label
                >
                <input
                  type="password"
                  name="confirm_password"
                  id="confirm_password"
                  autocomplete="confirm_password"
                  v-model="v$.form.confirm_password.$model"
                  class="
                    mt-1
                    focus:ring-indigo-500 focus:border-indigo-500
                    block
                    w-full
                    shadow-sm
                    sm:text-sm
                    border-gray-300
                    rounded-md
                  "
                />
                <!-- Error Message -->
                <div
                  class="input-errors"
                  v-for="(error, index) of v$.form.confirm_password.$errors"
                  :key="index"
                >
                  <div class="error-msg">{{ error.$message }}</div>
                </div>
                <div class="error-msg">{{ passwordError }}</div>
              </div>
            </div>
            <div class="px-4 py-3 text-right sm:px-6">
              <button
                @click="submitForm"
                type="submit"
                class="
                  inline-flex
                  justify-center
                  py-2
                  px-4
                  border border-transparent
                  shadow-sm
                  text-sm
                  font-medium
                  rounded-md
                  text-white
                  bg-indigo-600
                  hover:bg-indigo-700
                  focus:outline-none
                  focus:ring-2
                  focus:ring-offset-2
                  focus:ring-indigo-500
                "
              >
                Finalize registration
              </button>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import useVuelidate from "@vuelidate/core";
import { required, minLength } from "@vuelidate/validators";
import { mapActions, mapState } from "vuex";
import Error from "../../components/Error.vue";
export default {
  setup() {
    return { v$: useVuelidate() };
  },

  data() {
    return {
      form: {
        password: "",
        confirm_password: "",
      },
    };
  },

  methods: {
    ...mapActions("onboarding", ["savePassword", "submit"]),
    submitForm() {
      this.v$.$touch();
      if (
        !this.v$.$invalid &&
        this.form.password == this.form.confirm_password
      ) {
        this.savePassword(this.form);
        this.submit();
      }
    },
  },

  computed: {
    passwordError() {
      if (this.form.password !== this.form.confirm_password)
        return "Passwords do not match";
      return "";
    },
    ...mapState({
      message: (state) => state.onboarding.error,
    }),
  },

  validations() {
    return {
      form: {
        password: {
          required,
          min: minLength(8),
        },
        confirm_password: {
          required,
          min: minLength(8),
        },
      },
    };
  },
  components: {
    Error,
  },
};
</script>
