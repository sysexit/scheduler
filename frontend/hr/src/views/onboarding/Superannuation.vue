<template>
  <div class="md:col-span-2">
    <div
      class="
        my-3
        block
        text-sm text-left text-white
        bg-green-500
        h-12
        flex
        items-center
        p-4
        rounded-md
      "
      role="alert"
    >
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        class="w-6 h-6 mx-2 stroke-current"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
        ></path>
      </svg>
      Leave blank if you wish to use an employer nominated super fund.
    </div>
    <form @submit.prevent="validateBeforeSubmit">
      <div class="shadow overflow-hidden sm:rounded-md">
        <div class="px-4 py-5 bg-white sm:p-6">
          <div class="grid grid-cols-6 gap-6">
            <div class="col-span-6 sm:col-span-4">
              <label for="name" class="block text-sm font-medium text-gray-700"
                >Super fund name</label
              >
              <input
                type="text"
                name="name"
                id="name"
                v-model="v$.form.name.$model"
                class="
                  mt-1
                  focus:ring-indigo-500
                  focus:border-indigo-500
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
                v-for="(error, index) of v$.form.name.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-4">
              <label
                for="number"
                class="block text-sm font-medium text-gray-700"
                >Account number</label
              >
              <input
                type="tel"
                name="number"
                id="number"
                autocomplete="email"
                v-model="v$.form.number.$model"
                class="
                  mt-1
                  focus:ring-indigo-500
                  focus:border-indigo-500
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
                v-for="(error, index) of v$.form.number.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6">
              <label for="usi" class="block text-sm font-medium text-gray-700"
                >Super fund USI number</label
              >
              <input
                type="text"
                name="usi"
                id="usi"
                autocomplete="usi"
                v-model="v$.form.usi.$model"
                class="
                  mt-1
                  focus:ring-indigo-500
                  focus:border-indigo-500
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
                v-for="(error, index) of v$.form.usi.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6">
              <label
                for="webaddr"
                class="block text-sm font-medium text-gray-700"
                >Super fund web address</label
              >
              <input
                type="text"
                name="webaddr"
                id="webaddr"
                autocomplete="webaddr"
                v-model="v$.form.webaddr.$model"
                class="
                  mt-1
                  focus:ring-indigo-500
                  focus:border-indigo-500
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
                v-for="(error, index) of v$.form.webaddr.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>
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
              focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500
            "
          >
            Save
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import useVuelidate from "@vuelidate/core";
import { mapActions } from "vuex";
import { numeric, url } from "@vuelidate/validators";

export default {
  setup() {
    return { v$: useVuelidate() };
  },

  data() {
    return {
      form: {
        name: "",
        number: "",
        usi: "",
        webaddr: "",
      },
    };
  },

  validations() {
    return {
      form: {
        name: {},
        number: {
          numeric,
        },
        usi: {
          numeric,
        },
        webaddr: {
          url,
        },
      },
    };
  },

  methods: {
    ...mapActions("onboarding", ["saveSuper", "submit"]),
    async submitForm() {
      this.v$.$touch();
      if (!this.v$.$invalid) {
        this.saveSuper(this.form);
      }
    },
  },
};
</script>
