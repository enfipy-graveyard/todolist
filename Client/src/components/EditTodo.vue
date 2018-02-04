<template lang="pug">
v-layout(row, justify-center)
  v-dialog(v-model='isCreating', persistent, max-width='500px')
    v-btn(color='primary', dark, slot='activator') Add todo
    v-card
      v-card-title
        span.headline Edit Todo
      v-card-text
        v-container(grid-list-md)
          v-layout(wrap)
            v-flex(xs12)
              v-text-field(v-model='name', label='Name', required)
            v-flex(xs12)
              v-text-field(v-model='description', label='Description', required)
            v-flex(xs12)
              v-select(v-model='tags', label='Tags', multiple, autocomplete, chips,
              :items="['Shopping', 'Work', 'Fun', 'Goals', 'Movies to watch', 'Reading', 'Writing', 'Coding']")
      v-card-actions
        v-spacer
        v-btn(color='blue darken-1', flat, @click.native='isCreating = false') Cancel
        v-btn(color='blue darken-1', flat, @click.native='sendForm') Edit
</template>

<script>
  export default {
    props: ['todo'],
    data() {
      return {
        isCreating: false,
        name: this.todo.name,
        description: this.todo.description,
        tags: this.todo.tags,
      }
    },
    methods: {
      sendForm() {
        const name = this.name
        const description = this.description
        const tags = this.tags
        if (name.length > 0 && description.length > 0) {
          this.$emit('edit-todo', {
            name,
            description,
            tags,
          })

          this.name = ''
          this.description = ''
          this.tags = []
          this.isCreating = false
        }
      },
    },
  }
</script>
