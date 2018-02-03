<template lang="pug">
v-app
  v-toolbar(fixed, app, height='80')
    router-link.nav-link(to='/')
      v-toolbar-title(v-text='title')
    div(v-if='$store.state.authenticated')
      router-link.nav-link(to='/', @click.native='logout()')
        span Logout
    div(v-else)
      router-link.nav-link(to='/login')
        span Login
      router-link.nav-link(to='/registration')
        span Registration
  v-content
    v-container(fluid)
      transition(name='fade')
        router-view
  v-footer(app)
    span © 2018
    v-spacer
    span Created by dlarukov
</template>

<script>
import { LOGOUT } from '@/constants'

export default {
  data () {
    return {
      title: 'TodoList',
    }
  },
  methods: {
    logout() {
      this.$store.dispatch(LOGOUT)
    }
  }
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
