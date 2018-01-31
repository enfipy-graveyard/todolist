using System.Collections.Generic;
using Server.Models;

namespace Server.Abstractions
{
    public interface ITodo
    {
        IEnumerable<TodoModel> FetchTodos();
        TodoModel SaveTodo(TodoModel todo);
        TodoModel RemoveTodo(int id);
    }
}
