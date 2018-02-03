export default {
  todos(state) {
    return state.todos.map(item => ({
      body: item.body
    }))
  },

  tmp(state) {
    return state.todos
  }
}
