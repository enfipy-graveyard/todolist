using Server.BusinessLogic.Converters;
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

        public IEnumerable<TodoModel> FetchTodos()
        {
            return _applicationContext.Todos.Select(t => _todoConverter.GetModelByEntity(t));
        }

        public TodoModel SaveTodo(TodoModel todo)
        {
            var todoEntity = _todoConverter.GetEntityByModel(todo);
            var entity = _applicationContext.Todos.Add(todoEntity).Entity;
            _applicationContext.SaveChanges();
            return _todoConverter.GetModelByEntity(entity);
        }

        public TodoModel RemoveTodo(int id)
        {
            var todo = _applicationContext.Todos.FirstOrDefault(t => t.Id == id);
            _applicationContext.Todos.Remove(todo);
            _applicationContext.SaveChanges();
            return _todoConverter.GetModelByEntity(todo);
        }
    }
}
