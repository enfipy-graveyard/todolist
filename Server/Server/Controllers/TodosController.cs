using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Abstractions;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodo _todo;

        public TodosController(ITodo todo) { _todo = todo; }

        // GET api/todos
        [HttpGet]
        public IEnumerable<TodoModel> Get()
        {
            return _todo.FetchTodos();
        }

        // POST api/todos
        [HttpPost]
        public TodoModel Post([FromBody] TodoModel todo)
        {
            return _todo.SaveTodo(todo);
        }

        // POST api/todos/5
        [HttpPost("{id}")]
        public TodoModel Toggle(int id)
        {
            return _todo.ToggleTodo(id);
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public TodoModel Put(int id, [FromBody] TodoModel todo)
        {
            return _todo.EditTodo(id, todo.Name, todo.Description);
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public TodoModel Delete(int id)
        {
            return _todo.RemoveTodo(id);
        }
    }
}
