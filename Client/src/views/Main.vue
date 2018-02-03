<template lang="pug">
v-container(fluid)
  v-slide-y-transition(mode='out-in')
    v-layout(column, align-center)
      img.mb-5(src='@/assets/logo.png', alt='Vuetify.js')
      blockquote(v-if='$store.state.authenticated')
        | “First, solve the problem. Then, write the code.”
        footer
          small
            em John Johnson
</template>

<script>
export default {
  data () {
    return {
      title: 'Main'
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="stylus">

</style>
