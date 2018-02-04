<template lang="pug">
div
  todo.todo(v-on:delete-todo='$emit("delete-todo", todo)',
    v-on:complete-todo='$emit("complete-todo", todo)', v-on:edit-todo='$emit("edit-todo", todo)'
    v-for='todo in todos', :todo.sync='todo', v-bind:key='todo.id')
</template>

<script>
import Todo from './Todo'

export default {
  props: ['todos'],
  components: {
    Todo,
  },
}
</script>

<style scoped lang="stylus">
p.tasks
  text-align center

.todo
  margin-bottom 10px

</style>
