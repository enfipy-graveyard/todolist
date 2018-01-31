using System.Collections.Generic;
using Server.Models;

namespace Server.Abstractions
{
    public interface ITodo
    {
        IEnumerable<TodoModel> FetchTodos();
        TodoModel SaveTodo(TodoModel todo);
        TodoModel RemoveTodo(int id);
        TodoModel EditTodo(int id, string name, string description);
        TodoModel ToggleTodo(int id);
    }
}
