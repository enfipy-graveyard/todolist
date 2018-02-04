using Server.Data.Classes;
using Server.Models;
using System.Linq;

namespace Server.BusinessLogic.Converters
{
    public class TodoConverter : IModelEntityConverter<TodoModel, Todo>
    {
        private readonly IModelEntityConverter<TagModel, Tag> _tagConverter;

        public TodoConverter(IModelEntityConverter<TagModel, Tag> tagConverter)
        {
            _tagConverter = tagConverter;
        }

        public Todo GetEntityByModel(TodoModel model)
        {
            if (model == null) return null;
            return new Todo
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Completed = model.Completed,
                Date = model.Date,
                
                Tags = model.Tags?.Select(t => _tagConverter.GetEntityByModel(t)).ToList()
            };
        }

        public TodoModel GetModelByEntity(Todo entity)
        {
            if (entity == null) return null;
            return new TodoModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Completed = entity.Completed,
                Date = entity.Date,

                Tags = entity.Tags?.Select(t => _tagConverter.GetModelByEntity(t)).ToList()
            };
        }
    }
}
