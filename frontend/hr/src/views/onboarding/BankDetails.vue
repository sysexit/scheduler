<template>
  <div class="md:col-span-2">
    <form @submit.prevent="onSubmit">
      <div class="shadow overflow-hidden sm:rounded-md">
        <Alert :message="message" />
        <div class="px-4 py-5 bg-white sm:p-6">
          <div class="grid grid-cols-6 gap-6">
            <div class="col-span-6 sm:col-span-4">
              <label for="name" class="block text-sm font-medium text-gray-700"
                >Account name</label
              >
              <input
                type="text"
                name="name"
                id="name"
                v-model="v$.form.name.$model"
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
                v-for="(error, index) of v$.form.name.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-4">
              <label
                for="bsb-no"
                class="block text-sm font-medium text-gray-700"
                >BSB number</label
              >
              <input
                type="tel"
                name="bsb-no"
                id="bsb-no"
                autocomplete="email"
                v-model="v$.form.bsb.$model"
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
                v-for="(error, index) of v$.form.bsb.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6">
              <label
                for="acc-number"
                class="block text-sm font-medium text-gray-700"
                >Account number</label
              >
              <input
                type="text"
                name="acc-number"
                id="acc-number"
                autocomplete="acc-number"
                v-model="v$.form.number.$model"
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
                v-for="(error, index) of v$.form.number.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6">
              <label
                for="tfn-number"
                class="block text-sm font-medium text-gray-700"
                >Tax File Number</label
              >
              <input
                type="text"
                name="tfn-number"
                id="tfn-number"
                autocomplete="tfn-number"
                v-model="v$.form.tfn.$model"
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
                v-for="(error, index) of v$.form.tfn.$errors"
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
              focus:ring-2
              focus:ring-offset-2
              focus:ring-indigo-500
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
import { required, numeric, minLength, maxLength } from "@vuelidate/validators";
import Alert from "../../components/Alert.vue";

export default {
  setup() {
    return { v$: useVuelidate() };
  },

  data() {
    return {
      form: {
        name: "",
        bsb: "",
        number: "",
        tfn: "",
      },
      message: null,
    };
  },

  methods: {
    ...mapActions("onboarding", ["saveBank"]),
    submitForm() {
      this.v$.$touch();
      if (!this.v$.$invalid) {
        this.message = "Details saved";
        this.saveBank(this.form);
      }
    },
  },

  validations() {
    return {
      form: {
        name: {
          required,
        },
        bsb: {
          required,
          numeric,
          min: minLength(6),
          max: maxLength(6),
        },
        number: {
          required,
          numeric,
          min: minLength(4),
        },
        tfn: {
          required,
          numeric,
          min: minLength(8),
        },
      },
    };
  },

  components: {
    Alert,
  },
};
</script>
