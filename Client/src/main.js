import Vue from 'vue'
import Vuetify from 'vuetify'
import VueResource from 'vue-resource'
import 'vuetify/dist/vuetify.css'

import services from './services'
import store from './store'
import router from './router'
import sync from './router/sync'
import { CHECK_AUTH, FETCH } from './constants'

import App from './App'

Vue.use(VueResource)
Vue.use(Vuetify)

sync(store, router)

Vue.config.productionTip = false
Vue.http.headers.common.Authorization = services.auth.getAuthHeader().Authorization

store.dispatch(CHECK_AUTH).then(() => {
  if (store.state.authenticated) {
    store.dispatch(FETCH)
  }
})

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  template: '<App/>',
  components: { App },
})
