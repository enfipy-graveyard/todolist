import Vue from 'vue'
import {
  TODOS_URL,
  GET_TODOS, SAVE,
  DELETE, EDIT, COMPLETE_TODO
} from '@/constants'

export default {
  [GET_TODOS] () {
    return Vue.http.get(TODOS_URL).then(res => res.body)
  },

  [SAVE] (item) {
    item.tags = item.tags.map((el) => {
      const name = el
      return { name }
    })
    return Vue.http.post(TODOS_URL, item).then(res => res.body)
  },

  [COMPLETE_TODO] (id) {
    return Vue.http.post(`${TODOS_URL}/${id}`)
  },

  [EDIT] (item) {
    return Vue.http.post(`${TODOS_URL}/${item.id}`, item)
  },

  [DELETE] (id) {
    return Vue.http.delete(`${TODOS_URL}/${id}`)
  },
}
