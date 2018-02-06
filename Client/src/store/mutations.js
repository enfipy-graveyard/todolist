import {
  SET_IS_AUTHENTICATED,
  SAVE, EDIT, COMPLETE_TODO,
  DELETE, TODOS_LOADING,
  SAVE_TODOS, CHECK_AUTHORIZE
} from '@/constants'

export default {
  [SET_IS_AUTHENTICATED] (state, item) {
    state.authenticated = item.authenticated ? item.authenticated : false
  },

  [CHECK_AUTHORIZE] (state, item) {
    state.checkingIsAuthorized = item
  },

  [SAVE] (state, item) {
    state.todos.push(item)
  },

  [SAVE_TODOS] (state, items) {
    state.todos = items
  },

  [TODOS_LOADING] (state, item) {
    state.todosLoading = item
  },

  [DELETE] (state, item) {
    const index = state.todos.map(x => x.id).indexOf(item)
    if (index > -1) {
      state.todos.splice(index, 1)
    }
  },

  [COMPLETE_TODO] (state, item) {
    state.todos.find(el => el.id === item.id).completed = item.completed
  },

  [EDIT] (state, item) {
    state.todos[item] = item
  },
}
