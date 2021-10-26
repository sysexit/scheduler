<template>
  <div>
    <site-nav-bar />
    <site-contact />
    <site-hero />
    <div>
      <nuxt />
    </div>
    <site-footer />
  </div>
</template>

<script lang="ts">
import SiteNavBar from './partials/SiteNavBar.vue'
import SiteFooter from './partials/SiteFooter.vue'
import SiteContact from './partials/SiteContact.vue'
import SiteHero from './partials/SiteHero.vue'

export default {
  components: {
    SiteNavBar,
    SiteFooter,
    SiteContact,
    SiteHero,
  },
}
</script>
