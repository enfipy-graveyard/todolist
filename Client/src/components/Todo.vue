<template lang="pug">
v-layout
  v-flex(xs12)
    v-card.card(:class='{ done: todo.completed }')
      v-card-title
        div
          span.headline(v-text='todo.name')
          br
          span(v-text='todo.description')
          br
          v-chip.chip(v-for='tag in todo.tags', v-text='tag.name', v-bind:key='todo.id', color='pink', text-color='white')
      v-card-actions
        v-spacer
        v-btn(flat, color='red', @click='$emit("delete-todo", todo)') Delete
        //- v-btn(flat, color='orange', @click='$emit("edit-todo", todo)') Edit
        v-btn(flat, color='green', @click='$emit("complete-todo", todo)') {{ todo.completed ? 'Uncomplete' : 'Complete' }}
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

<style lang="stylus" scoped>

.card
  width 500px

.done
  background #ededed

.chip
  margin-left 0px
  margin-right 8px
  padding 5px

</style>

