<template lang="pug">
div
  todo.todo(v-on:delete-todo='deleteTodo', v-on:complete-todo='completeTodo', v-on:edit-todo='editTodo'
    v-for='todo in todos', :todo.sync='todo', v-bind:key='todo.id')
</template>

<script>
import Todo from './Todo'

export default {
  props: ['todos'],
  components: {
    Todo,
  },
  methods: {
    deleteTodo(todo) {
      console.log(todo)
    },
    completeTodo(todo) {
      console.log(todo)
    },
    editTodo(todo) {
      console.log(todo)
    },
  },
}
</script>

<style scoped lang="stylus">
p.tasks
  text-align center

.todo
  margin-bottom 10px

</style>
