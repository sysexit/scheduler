<template>
  <nav class="w-full p-6 pl-0 bg-transparent sm:container mx-auto">
    <div class="navbar-items flex items-center">
      <!-- Header logo -->
      <div class="logo">
        <Logo />
      </div>

      <!-- Mobile toggle -->
      <div class="md:hidden">
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

      <!-- Navbar -->
      <div class="hidden md:block">
        <ul class="flex ml-10 space-x-8 text-sm font-sans">
          <li><a href="/" class="">Home</a></li>
          <!-- <li><a href="/catering" class="">Catering</a></li> -->
          <li><a href="/jobs" class="">Jobs</a></li>
          <!-- <li><a href="/contact" class="">Contact</a></li> -->
          <li>
            <a
              href="/Brand-Menu.pdf"
              class="
                cta
                bg-blue-500
                hover:bg-blue-600
                px-3
                py-2
                rounded
                text-white
                font-semibold
              "
              >Menu</a
            >
          </li>
        </ul>
      </div>

      <!-- Dark Background Transition -->
      <transition
        enter-class="opacity-0"
        enter-active-class="ease-out transition-medium"
        enter-to-class="opacity-100"
        leave-class="opacity-100"
        leave-active-class="ease-out transition-medium"
        leave-to-class="opacity-0"
      >
        <div
          @keydown.esc="isOpen = false"
          v-show="isOpen"
          class="z-10 fixed inset-0 transition-opacity"
        >
          <div
            @click="isOpen = false"
            class="absolute inset-0 bg-black opacity-50"
            tabindex="0"
          ></div>
        </div>
      </transition>

      <!-- Drawer Menu -->
      <aside
        class="
          p-5
          transform
          top-0
          left-0
          w-64
          bg-white
          fixed
          h-full
          overflow-auto
          ease-in-out
          transition-all
          duration-300
          z-30
        "
        :class="isOpen ? 'translate-x-0' : '-translate-x-full'"
      >
        <div class="close">
          <button
            class="absolute top-0 right-0 mt-4 mr-4"
            @click="isOpen = false"
          >
            <svg
              class="w-6 h-6"
              fill="none"
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path d="M6 18L18 6M6 6l12 12"></path>
            </svg>
          </button>
        </div>

        <ul class="divide-y font-sans">
          <li>
            <a href="/" @click="isOpen = false" class="my-4 inline-block"
              >Home</a
            >
          </li>
          <!-- <li>
            <a
              href="/catering"
              @click="isOpen = false"
              class="my-4 inline-block"
              >Catering</a
            >
          </li> -->
          <li>
            <a href="/jobs" @click="isOpen = false" class="my-4 inline-block"
              >Jobs</a
            >
          </li>
          <!-- <li>
            <a href="/contact" @click="isOpen = false" class="my-4 inline-block"
              >Contact</a
            >
          </li> -->
          <li>
            <a
              href="/Brand-Menu.pdf"
              @click="isOpen = false"
              class="
                my-8
                w-full
                text-center
                font-semibold
                cta
                inline-block
                bg-blue-500
                hover:bg-blue-600
                px-3
                py-2
                rounded
                text-white
              "
              >Menu</a
            >
          </li>
        </ul>

        <div class="follow">
          <p class="italic font-sans text-sm">follow us:</p>
          <div class="social flex space-x-5 mt-4">
            <a href="https://www.facebook.com/Brand">
              <svg
                aria-hidden="true"
                focusable="false"
                data-prefix="fab"
                data-icon="facebook-f"
                class="h-5 w-5 fill-current text-gray-600"
                role="img"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 320 512"
              >
                <path
                  fill="currentColor"
                  d="M279.14 288l14.22-92.66h-88.91v-60.13c0-25.35 12.42-50.06 52.24-50.06h40.42V6.26S260.43 0 225.36 0c-73.22 0-121.08 44.38-121.08 124.72v70.62H22.89V288h81.39v224h100.17V288z"
                ></path>
              </svg>
            </a>
          </div>
        </div>
      </aside>
    </div>
  </nav>
</template>

<script>
import Logo from '../../components/Logo.vue'

export default {
  data() {
    return {
      isOpen: false,
    }
  },
  methods: {
    drawer() {
      this.isOpen = !this.isOpen
    },
  },
  watch: {
    isOpen: {
      immediate: true,
      handler(isOpen) {
        if (process.client) {
          if (isOpen) document.body.style.setProperty('overflow', 'hidden')
          else document.body.style.removeProperty('overflow')
        }
      },
    },
  },
  mounted() {
    document.addEventListener('keydown', (e) => {
      if (e.keyCode == 27 && this.isOpen) this.isOpen = false
    })
  },
  components: {
    Logo,
  },
}
</script>

<style lang="scss" scoped>
@media only screen and (max-width: 767px),
  only screen and (max-device-width: 767px) {
  .logo {
    margin-left: 20px;
  }
  .navbar-items {
    justify-content: space-between;
  }
}
</style>