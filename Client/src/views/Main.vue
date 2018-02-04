<template lang="pug">
v-container(fluid)
  v-slide-y-transition(mode='out-in')

    v-layout(column, align-center, v-if='$store.state.authenticated')
      .headline(style='margin: 10px') Vue.js Todo App
      todo-list(v-bind:todos='$store.state.todos')
      create-todo(v-on:create-todo='createTodo')

    v-layout(column, align-center, v-else)
      .headline(style='margin: 10px') Login or signup to write down todos
      v-btn(flat, color='gray', to='/login')
        span To Login page
      v-btn(flat, color='gray', to='/registration')
        span To Registration page
</template>

<script>
import { SAVE } from '@/constants'
import TodoList from '@/components/TodoList'
import CreateTodo from '@/components/CreateTodo'

export default {
  data () {
    return {
      visibility: 'all'
    }
  },
  components: {
    TodoList,
    CreateTodo
  },
  methods: {
    createTodo(newTodo) {
      this.$store.dispatch(SAVE, newTodo)
    },
  }
}
</script>

<style lang="stylus" scoped>

@import '../assets/style.styl'

</style>

