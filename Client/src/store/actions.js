import Vue from 'vue'

export function fetch(context) {
  const url = 'https://jsonplaceholder.typicode.com/posts?userId=1'

  Vue.http.get(url)
    .then((res) => {
      const results = res.body
      context.commit('set', { type: 'messages', items: results })
    }, (error) => {
      // eslint-disable-next-line
      console.log(error)
    })
}

export function save(context, payload) {
  context.commit('sendMessage', {
    username: 'lol',
    body: payload,
    date: Date.now()
  })
}
