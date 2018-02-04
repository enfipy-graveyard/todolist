<template lang="pug">
v-layout
  v-flex(xs12)
    v-card(style='width: 500px')
      v-card-title
        div
          span.headline(v-text='todo.name')
          br
          span(v-text='todo.description')
      v-card-actions
        v-spacer
        v-btn(flat, color='red', @click='deleteTodo(todo)') Delete
        v-btn(flat, color='orange', @click='editTodo(todo)') Edit
        v-btn(flat, color='green', @click='completeTodo(todo)') Complete
</template>

<script>
  export default {
    props: ['todo'],
    data() {
      return {
        isEditing: false,
      }
    },
    methods: {
      completeTodo(todo) {
        this.$emit('complete-todo', todo)
      },
      deleteTodo(todo) {
        this.$emit('delete-todo', todo)
      },
      editTodo(todo) {
        this.$emit('edit-todo', todo)
      },
    },
  }
</script>
