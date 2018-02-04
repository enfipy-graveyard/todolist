import { SET_IS_AUTHENTICATED, SAVE, SAVE_TODOS } from '@/constants'

export default {
  [SET_IS_AUTHENTICATED] (state, item) {
    state.authenticated = item.authenticated ? item.authenticated : false
  },

  [SAVE] (state, item) {
    state.todos.push(item)
  },

  [SAVE_TODOS] (state, items) {
    state.todos = items
  },
}
