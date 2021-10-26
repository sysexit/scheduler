<template>
  <div class="min-h-screen bg-no-repeat bg-cover bg-center">
    <div
      class="md:hidden w-full p-6 bg-transparent sm:container mx-auto"
      :class="isOpen ? 'hidden' : ''"
    >
      <button @click="drawer">
        <svg
          class="h-8 w-8 fill-current text-black"
          fill="none"
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path d="M4 6h16M4 12h16M4 18h16"></path>
        </svg>
      </button>
    </div>
    <div class="flex justify-end">
      <div
        class="
          bg-white
          min-h-screen
          lg:w-1/2
          flex
          justify-center
          md:items-center
          flex
          mobileview
        "
        :class="isOpen ? 'active' : ''"
      >
        <div class="m-5">
          <Error :message="message" class="mb-5" />
          <h1
            class="
              text-center text-2xl
              font-normal
              leading-normal
              mt-0
              text-purple-800
            "
          >
            Employee Onboarding
          </h1>
          <p class="mb-10 text-center">
            Please fill out all fields in the following forms.
          </p>
          <router-link
            @click="isOpen = false"
            class="button"
            :to="{
              name: 'personal',
              params: { token: this.$route.params.token },
            }"
          >
            Personal Details
          </router-link>
          <router-link
            @click="isOpen = false"
            class="button"
            :to="{ name: 'bank', params: { token: this.$route.params.token } }"
          >
            Bank Details
          </router-link>
          <router-link
            @click="isOpen = false"
            class="button"
            :to="{ name: 'super', params: { token: this.$route.params.token } }"
          >
            Superannuation
          </router-link>
          <div class="py-3 flex">
            <button
              @click="saveAll"
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
                bg-green-600
                hover:bg-green-700
                focus:outline-none
                focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500
                mr-auto
                ml-auto
              "
            >
              Finalize details and submit
            </button>
          </div>
        </div>
      </div>
      <div
        class="
          bg-white
          min-h-screen
          lg:w-1/2
          flex
          justify-center
          items-center
          info-form
          w-full
          z-0
        "
      >
        <router-view />
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";
import Error from "../../../components/Error.vue";
export default {
  data() {
    return {
      isOpen: true,
    };
  },
  methods: {
    ...mapActions("onboarding", ["saveAll"]),
    drawer() {
      this.isOpen = !this.isOpen;
    },
  },
  computed: {
    ...mapState({
      message: (state) => state.onboarding.error,
    }),
  },
  watch: {
    isOpen: {
      immediate: true,
      handler(isOpen) {
        if (process.client) {
          if (isOpen) document.body.style.setProperty("overflow", "hidden");
          else document.body.style.removeProperty("overflow");
        }
      },
    },
  },
  mounted() {
    document.addEventListener("keydown", (e) => {
      if (e.keyCode == 27 && this.isOpen) this.isOpen = false;
    });
  },
  components: {
    Error,
  },
};
</script>

<style lang="scss" scoped>
body {
  overflow: hidden;
}

.button {
  display: flex;
  border: 1px solid #d8d7dc;
  padding: 20px;
  height: 90px;
  margin-bottom: 15px;

  color: #3d1cba;
  font-size: 18px;
  font-weight: 600;
  line-height: 18px;
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;
  padding: 0 0 0 10px;
  box-sizing: border-box;
  width: 100%;
  text-align: center;
}

@media only screen and (max-width: 550px),
  only screen and (max-device-width: 550px) {
  .mobileview {
    position: absolute;
    left: -200%;
    transition: left 0.6s ease;
    height: 200%;
    z-index: 5;
  }

  .active {
    left: 0;
  }
  .info-form {
    padding: 0 20px 20px 20px;
    display: block !important;
  }
}
</style>
