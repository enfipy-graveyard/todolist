<template lang="pug">
v-container(fluid)
  v-slide-y-transition(mode='out-in')
    v-layout(column, align-center)
      blockquote
        | Page Not Found 
        footer
          small
            em
              | Sorry, but the page you're looking for is missing - it might be deleted at all or the URL might be misspelled.
</template>


<script>
export default {
  data () {
    return {}
  }
}
</script>
