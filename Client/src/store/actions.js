import Vue from 'vue'
import services from '@/services'
import {
  SET_IS_AUTHENTICATED,
  LOGIN, REGISTRATION,
  LOGOUT, CHECK_AUTH,
  FETCH, SAVE
} from '@/constants'

const govnoCod = (context, body) => {
  if (body.length > 50) {
    context.commit(SET_IS_AUTHENTICATED, { authenticated: true })
    return { success: true }
  }
  return { success: false, error: body }
}

export default {
  [LOGIN] (context, creds) {
    return services.auth[LOGIN](creds)
      .then(res => govnoCod(context, res.body))
  },

  [REGISTRATION] (context, creds) {
    return services.auth[REGISTRATION](creds)
      .then(res => govnoCod(context, res.body))
  },

  [LOGOUT] (context) {
    services.auth[LOGOUT]()
    context.commit(SET_IS_AUTHENTICATED, { authenticated: false })
  },

  [CHECK_AUTH] (context) {
    const authenticated = services.auth[CHECK_AUTH]()
    context.commit(SET_IS_AUTHENTICATED, { authenticated })
  },

  [FETCH] (context) {
    const url = 'https://jsonplaceholder.typicode.com/posts?userId=1'
    Vue.http.get(url)
      .then((res) => {
        const results = res.body
        context.commit('set', { type: 'messages', items: results })
      }, (error) => {
        // eslint-disable-next-line
        console.log(error)
      })
  },

  [SAVE] (context, payload) {
    context.commit('sendMessage', {
      username: 'lol',
      body: payload,
      date: Date.now()
    })
  },
}
