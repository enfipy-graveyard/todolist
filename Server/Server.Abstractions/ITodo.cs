using System.Collections.Generic;
using Server.Models;

namespace Server.Abstractions
{
    public interface ITodo
    {
        IEnumerable<TodoModel> FetchTodos(string login);
        TodoModel SaveTodo(string login, TodoModel todo);
        bool RemoveTodo(string login, int id);
        TodoModel EditTodo(string login, int id, string name, string description);
        TodoModel ToggleTodo(string login, int id);
    }
}
