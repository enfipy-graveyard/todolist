<template lang="pug">
v-app
  v-toolbar(fixed, app, height='80')
    router-link.nav-link(to='/')
      v-toolbar-title.title(v-text='title')
    router-link.nav-link(to='/NotFound')
      span Hello
    v-spacer
    v-btn(icon, @click.stop='$store.dispatch("chatToggle")')
      v-icon chat
  v-content
    v-container(fluid)
      transition(name='fade')
        router-view
  v-footer(app)
    span © 2018
</template>

<script>
export default {
  data () {
    return {
      title: 'Title'
    }
  },
  components: { }
}
</script>

<style lang="stylus" scoped>

@import './assets/style.styl';

a
  font-family Arial, Helvetica, sans-serif
  text-decoration none
  text-align center
  color #666 !important

.fade-enter-active, .fade-leave-active
  transition-property opacity
  transition-duration .25s

.fade-enter-active
  transition-delay .25s

.fade-enter, .fade-leave-active
  opacity 0

.nav-link
  font-weight 300
  font-size 20px
  margin-left 20px

.toolbar__title
  font-weight 300
  font-size 30px !important
  position relative

.navigation-drawer
  padding-bottom formHeight

</style>
