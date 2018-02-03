<template lang="pug">
.col-sm-4.col-sm-offset-4
  h2 Log In
  p Log in to your account to get some great quotes.
  .alert.alert-info(style='color: black', v-if='error')
    p {{ error }}
  .form-group
    input.form-control(type='text', placeholder='Enter your login', v-model='credentials.login')
  .form-group
    input.form-control(type='password', placeholder='Enter your password', v-model='credentials.password')
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
      error: ''
    }
  },
  methods: {
    submit() {
      this.$store.dispatch(LOGIN, this.credentials).then((res) => {
        if (res.success) {
          this.$router.push({ path: '/' })
        } else {
          this.error = res.error
        }
      }).catch((err) => {
        console.log(err)
      })
    }
  }
}
</script>
