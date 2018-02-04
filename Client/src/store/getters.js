export default {
  all(state) {
    return state.todos
  },

  active(state) {
    return state.todos.filter(todo => !todo.completed)
  },

  completed(state) {
    return state.todos.filter(todo => todo.completed)
  }
}
