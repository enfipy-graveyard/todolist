using Server.Data.Classes;
using Server.Models;

namespace Server.BusinessLogic.Converters
{
    public class TodoConverter : IModelEntityConverter<TodoModel, Todo>
    {
        public Todo GetEntityByModel(TodoModel model)
        {
            return new Todo
            {
                Id = model.Id,
                Data = model.Data,
                Complited = model.Complited
            };
        }

        public TodoModel GetModelByEntity(Todo entity)
        {
            return new TodoModel
            {
                Id = entity.Id,
                Data = entity.Data,
                Complited = entity.Complited
            };
        }
    }
}
