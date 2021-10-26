<template>
  <div>
    <div class="content flex max-w-4xl" style="margin: 0 auto">
      <div class="flex-wrap">
        <div class="flex row zdf">
          <div class="inner p-10">
            <h1 class="title">Careers at Brand</h1>
            <div>
              <h1>Applying</h1>
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
            </div>
            <div>
              <h1>Currently open positions</h1>
            </div>
            <div>
              <ul v-if="jobs.length">
                <li v-for="job of jobs" :key="job.slug">
                  <NuxtLink :to="'/jobs/' + job.slug">
                    {{ job.title }}
                  </NuxtLink>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  async asyncData({ $content, params }) {
    const jobs = await $content('jobs').only(['title', 'type', 'slug']).fetch()

    return {
      jobs,
    }
  },
}
</script>
