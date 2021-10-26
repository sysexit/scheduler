<template>
  <div class="md:col-span-2">
    <form @submit.prevent="onSubmit">
      <div class="shadow overflow-hidden sm:rounded-md">
        <div class="px-4 py-5 bg-white sm:p-6">
          <div class="grid grid-cols-6 gap-6">
            <div class="col-span-6 sm:col-span-4">
              <label
                for="preferred_name"
                class="block text-sm font-medium text-gray-700"
                >Start date</label
              >
              <input
                type="date"
                name="preferred_name"
                id="preferred_name"
                v-model="v$.form.startdate.$model"
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
                v-for="(error, index) of v$.form.startdate.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-4">
              <label
                for="preferred_name"
                class="block text-sm font-medium text-gray-700"
                >Preferred name (optional)</label
              >
              <input
                type="text"
                name="preferred_name"
                id="preferred_name"
                v-model="v$.form.preferred_name.$model"
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
            </div>

            <div class="col-span-6 sm:col-span-4">
              <label for="visa" class="block text-sm font-medium text-gray-700"
                >Work visa number</label
              >
              <input
                type="text"
                name="visa"
                id="visa"
                v-model="v$.form.visa.$model"
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
                v-for="(error, index) of v$.form.visa.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-4">
              <label
                for="date-of-birth"
                class="block text-sm font-medium text-gray-700"
                >Date of birth</label
              >
              <input
                type="date"
                name="date-of-birth"
                id="date-of-birth"
                autocomplete="email"
                v-model="v$.form.dateofbirth.$model"
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
                v-for="(error, index) of v$.form.dateofbirth.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-4">
              <label
                for="phone-no"
                class="block text-sm font-medium text-gray-700"
                >Phone number</label
              >
              <input
                type="tel"
                name="phone-no"
                id="phone-no"
                autocomplete="email"
                v-model="v$.form.phone.$model"
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
                v-for="(error, index) of v$.form.phone.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6">
              <label
                for="address"
                class="block text-sm font-medium text-gray-700"
                >Address</label
              >
              <input
                type="text"
                name="address"
                id="address"
                autocomplete="address"
                v-model="v$.form.address.$model"
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
                v-for="(error, index) of v$.form.address.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-6 lg:col-span-2">
              <label for="city" class="block text-sm font-medium text-gray-700"
                >City</label
              >
              <input
                type="text"
                name="city"
                id="city"
                v-model="v$.form.city.$model"
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
                v-for="(error, index) of v$.form.city.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-3 lg:col-span-2">
              <label for="state" class="block text-sm font-medium text-gray-700"
                >State</label
              >
              <input
                type="text"
                name="state"
                id="state"
                v-model="v$.form.state.$model"
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
                v-for="(error, index) of v$.form.state.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>

            <div class="col-span-6 sm:col-span-3 lg:col-span-2">
              <label
                for="postal-code"
                class="block text-sm font-medium text-gray-700"
                >ZIP / Postal</label
              >
              <input
                type="text"
                name="postal-code"
                id="postal-code"
                autocomplete="postal-code"
                v-model="v$.form.zip.$model"
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
                v-for="(error, index) of v$.form.zip.$errors"
                :key="index"
              >
                <div class="error-msg">{{ error.$message }}</div>
              </div>
            </div>
          </div>
        </div>
        <Alert :message="message" />
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
import { required, numeric, alpha, alphaNum } from "@vuelidate/validators";
import Alert from "../../components/Alert.vue";

export default {
  setup() {
    return { v$: useVuelidate() };
  },

  data() {
    return {
      form: {
        startdate: "",
        dateofbirth: "",
        preferred_name: "",
        visa: "",
        phone: "",
        address: "",
        city: "",
        state: "",
        zip: "",
      },
      message: null,
    };
  },

  methods: {
    ...mapActions("onboarding", ["savePersonal"]),
    submitForm() {
      this.v$.$touch();
      if (!this.v$.$invalid) {
        this.message = "Details saved";
        this.savePersonal(this.form);
      }
    },
  },

  validations() {
    return {
      form: {
        startdate: {},
        preferred_name: {},
        visa: {},
        dateofbirth: {
          required,
        },
        phone: {
          required,
          numeric,
        },
        address: {
          required,
        },
        city: {
          required,
        },
        state: {
          required,
        },
        zip: {
          required,
          numeric,
        },
      },
    };
  },
  components: {
    Alert,
  },
};
</script>
