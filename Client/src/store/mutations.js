export function edit(state, { type, items }) {
  state[type] = items
}

export function chatToggle(state) {
  state.chat = !state.chat
}

export function sendMessage(state, item) {
  state.messages.push(item)
}
