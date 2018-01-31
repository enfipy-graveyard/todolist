export function todos(state) {
  return state.todos.map(item => ({
    body: item.body
  }))
}

export function tmp(state) {
  return state.messages.map(item => ({
    username: 'Bret',
    body: item.title
  }))
}
