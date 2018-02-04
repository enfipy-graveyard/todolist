using Server.BusinessLogic.Converters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Server.Abstractions;
using Server.Data.Classes;
using Server.Models;
using Server.Data;
using System.Linq;

namespace Server.BusinessLogic
{
    public class TodoService : ITodo
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IModelEntityConverter<TodoModel, Todo> _todoConverter;

        public TodoService(ApplicationContext applicationContext, IModelEntityConverter<TodoModel, Todo> todoConverter)
        {
            _applicationContext = applicationContext;
            _todoConverter = todoConverter;
        }

        public IEnumerable<TodoModel> FetchTodos(string login)
        {
            var user = _applicationContext.Users.Include(u => u.Todos)
                .ThenInclude(t => t.Tags).FirstOrDefault(u => u.Login == login);
            return user.Todos.Select(t => _todoConverter.GetModelByEntity(t));
        }

        public TodoModel SaveTodo(string login, TodoModel todo)
        {
            var todoEntity = _todoConverter.GetEntityByModel(todo);
            var user = _applicationContext.Users.FirstOrDefault(u => u.Login == login);
            user.Todos.Add(todoEntity);
            _applicationContext.SaveChanges();
            return _todoConverter.GetModelByEntity(todoEntity);
        }

        public bool RemoveTodo(string login, int id)
        {
            var user = _applicationContext.Users.Include(u => u.Todos).FirstOrDefault(u => u.Login == login);
            var todo = user.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return false;
            var res = user.Todos.Remove(todo);
            _applicationContext.SaveChanges();
            return res;
        }

        public TodoModel EditTodo(string login, int id, string name, string description)
        {
            var user = _applicationContext.Users.Include(u => u.Todos).FirstOrDefault(u => u.Login == login);
            var todo = user.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return null;
            todo.Name = string.IsNullOrEmpty(name) ? todo.Name : name;
            todo.Description = string.IsNullOrEmpty(name) ? todo.Description : description;
            _applicationContext.SaveChanges();
            return _todoConverter.GetModelByEntity(todo);
        }

        public TodoModel ToggleTodo(string login, int id)
        {
            // TODO: Pattern Command
            var user = _applicationContext.Users.Include(u => u.Todos).FirstOrDefault(u => u.Login == login);
            var todo = user.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return null;
            todo.Completed = !todo.Completed;
            _applicationContext.SaveChanges();
            return _todoConverter.GetModelByEntity(todo);
        }
    }
}
