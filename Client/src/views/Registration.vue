<template lang="pug">
.col-sm-4.col-sm-offset-4
  h2 Registration
  p Sign up for a free account to access possibilities write down todos.
  .alert.alert-info(style='color: black', v-if='error')
    p {{ error }}
  .form-group
    input.form-control(type='text', placeholder='Enter your login', v-model='credentials.login')
  .form-group
    input.form-control(type='password', placeholder='Enter your password', v-model='credentials.password')
  button.btn.btn-primary(@click='submit()') SignUp
</template>

<script>
import { REGISTRATION } from '@/constants'

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
  // beforeCreate: () => {
  //   if (this.$store.state.authenticated) {
  //     this.$router.push({ path: '/' })
  //   }
  // },
  methods: {
    submit() {
      this.$store.dispatch(REGISTRATION, this.credentials).then((res) => {
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