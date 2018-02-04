using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Abstractions;
using Server.Models;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodo _todo;

        public TodosController(ITodo todo) { _todo = todo; }

        // GET api/todos
        [HttpGet]
        public IEnumerable<TodoModel> Get()
        {
            return _todo.FetchTodos(User.Identity.Name);
        }

        // POST api/todos
        [HttpPost]
        public TodoModel Post([FromBody] TodoModel todo)
        {
            if (todo == null) return null;
            return _todo.SaveTodo(User.Identity.Name, todo);
        }

        // POST api/todos/5
        [HttpPost("{id}")]
        public TodoModel Toggle(int id)
        {
            return _todo.ToggleTodo(User.Identity.Name, id);
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public TodoModel Put(int id, [FromBody] TodoModel todo)
        {
            if (todo != null) return null;
            return _todo.EditTodo(User.Identity.Name, id, todo.Name, todo.Description);
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _todo.RemoveTodo(User.Identity.Name, id);
        }
    }
}
