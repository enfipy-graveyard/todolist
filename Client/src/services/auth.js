import Vue from 'vue'
import {
  ID_TOKEN,
  LOGIN_URL, SIGNUP_URL,
  LOGIN, REGISTRATION,
  LOGOUT, CHECK_AUTH,
  AUTHORIZE,
  GET_AUTH_HEADER
} from '@/constants'

export default {
  [LOGIN] (creds) {
    return Vue.http.post(LOGIN_URL, creds).then((res) => {
      localStorage.setItem(ID_TOKEN, res.body)
      return res
    })
  },

  [REGISTRATION] (creds) {
    return Vue.http.post(SIGNUP_URL, creds).then((res) => {
      localStorage.setItem(ID_TOKEN, res.body)
      return res
    })
  },

  [AUTHORIZE] () {
    const isAuthorized = this[CHECK_AUTH]()
    if (isAuthorized) {
      const authHeader = this[GET_AUTH_HEADER]()
      Vue.http.headers.common.Authorization = authHeader.Authorization
      return true
    }
    return false
  },

  [LOGOUT] () {
    localStorage.removeItem(ID_TOKEN)
  },

  [CHECK_AUTH] () {
    const jwt = localStorage.getItem(ID_TOKEN)
    return Boolean(jwt)
  },

  [GET_AUTH_HEADER] () {
    return {
      Authorization: `Bearer ${localStorage.getItem(ID_TOKEN)}`
    }
  },
}
