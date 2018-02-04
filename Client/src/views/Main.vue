<template lang="pug">
v-container(fluid)
  v-slide-y-transition(mode='out-in')

    v-layout(column, align-center, v-if='$store.state.authenticated')
      .headline(style='margin: 10px') Vue.js Todo App
      v-text-field(prepend-icon='search', v-model='search', hide-details, single-line, style='width: 400px')
      .filters
        v-btn(flat, color='gray', @click='visibility = "all"')
          span All
        v-btn(flat, color='gray', @click='visibility = "active"')
          span Active
        v-btn(flat, color='gray', @click='visibility = "completed"')
          span Completed
      todo-list(v-bind:todos='filteredTodos', v-on:delete-todo='deleteTodo',
        v-on:complete-todo='completeTodo', v-on:edit-todo='editTodo')
      create-todo(v-on:create-todo='createTodo')
      //- edit-todo(v-if='selectedEditTodo', todo.sync='selectedEditTodo', v-on:edit-todo='editTodo')

    v-layout(column, align-center, v-else)
      .headline(style='margin: 10px') Login or signup to write down todos
      v-btn(flat, color='gray', to='/login')
        span To Login page
      v-btn(flat, color='gray', to='/registration')
        span To Registration page
</template>

<script>
import { SAVE, DELETE, EDIT, COMPLETE_TODO } from '@/constants'
import TodoList from '@/components/TodoList'
import CreateTodo from '@/components/CreateTodo'
import EditTodo from '@/components/EditTodo'

export default {
  data () {
    return {
      visibility: 'all',
      search: '',
      editedTodo: null,
      items: ['Item One', 'Item Seventeen', 'Item Five']
    }
  },
  components: {
    TodoList,
    EditTodo,
    CreateTodo
  },
  methods: {
    createTodo(newTodo) {
      this.$store.dispatch(SAVE, newTodo)
    },
    deleteTodo(todo) {
      this.$store.dispatch(DELETE, todo.id)
    },
    completeTodo(todo) {
      this.$store.dispatch(COMPLETE_TODO, todo.id)
    },
    editTodo(todo) {
      this.$store.dispatch(EDIT, todo)
    }
  },
  computed: {
    filteredTodos() {
      const todos = this.$store.getters[this.visibility]
      if (this.search) {
        return todos.filter(item => item.name.indexOf(this.search)
          || item.description.indexOf(this.search))
      }
      return todos
    },
  }
}
</script>
