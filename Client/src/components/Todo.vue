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
        v-btn(flat, color='red', @click='$emit("delete-todo", todo)') Delete
        v-btn(flat, color='orange', @click='$emit("edit-todo", todo)') Edit
        v-btn(flat, color='green', @click='$emit("complete-todo", todo)') Complete
</template>

<script>
  export default {
    props: ['todo'],
    data() {
      return {
        isEditing: false,
      }
    },
  }
</script>
