<template>
  <div>
    <div class="content flex max-w-4xl" style="margin: 0 auto">
      <div class="flex-wrap">
        <div class="flex row zdf">
          <div class="inner p-10">
            <div class="job-info">
              <div class="job-details mb-3">
                <h1>{{ page.title }}</h1>
                <h2>{{ page.type }}</h2>
              </div>
            </div>
            <div>
              <nuxt-content :document="page" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  async asyncData({ params, $content }) {
    const pathMatch = params.pathMatch.endsWith('/')
      ? params.pathMatch.slice(0, -1)
      : params.pathMatch
    const path = pathMatch.includes('/') ? pathMatch : `${pathMatch}/index`
    console.log('path')
    console.log(path)

    const page = await $content(path).fetch()
    return {
      page,
    }
  },
  data() {
    return {
      page: null,
    }
  },
}
</script>

<style scoped>
.job-info {
  margin-bottom: 30px;
}

/* Markdown styling */
.nuxt-content ul {
  margin: revert;
  padding: revert;
  list-style: revert;
}
.nuxt-content h2 {
  margin-top: 25px;
  font-weight: 600;
}
.nuxt-content p {
  margin: 6px 0 6px 0;
}
</style>