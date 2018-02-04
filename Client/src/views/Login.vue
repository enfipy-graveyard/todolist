<template lang="pug">
v-container(fluid)
  v-slide-y-transition(mode='out-in')
    v-layout(column, align-center)
      h2 Login
      p Log in to your account to access possibilities write down todos.
      v-alert(color='error', icon='warning', value='true', v-if='error' v-text='error')
      v-form(style='width: 300px')
        v-text-field(label='Enter your login', v-model='credentials.login', required)
        v-text-field(label='Enter your password', v-model='credentials.password', type='password', required)
      button.btn.btn-primary(@click='submit()') Access
</template>

<script>
import { LOGIN } from '@/constants'

export default {
  data() {
    return {
      credentials: {
        login: '',
        password: ''
      },
      error: '',
      processing: false
    }
  },
  methods: {
    submit() {
      if (this.processing) return
      this.processing = true

      this.$store.dispatch(LOGIN, this.credentials).then((res) => {
        if (res.success) {
          this.$router.push({ path: '/' })
        } else {
          this.error = res.error
        }
        this.processing = false
      }).catch((err) => {
        console.log(err)
        this.processing = false
      })
    }
  }
}
</script>
