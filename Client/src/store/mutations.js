import { SET_IS_AUTHENTICATED, SEND_MESSAGE } from '@/constants'

export default {
  [SET_IS_AUTHENTICATED] (state, item) {
    state.authenticated = item.authenticated ? item.authenticated : false
  },

  [SEND_MESSAGE] (state, item) {
    state.messages.push(item)
  },
}
