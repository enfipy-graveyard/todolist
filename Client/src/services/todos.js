import Vue from 'vue'
import {
  TODOS_URL,
  GET_TODOS, SAVE
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
  }
}
