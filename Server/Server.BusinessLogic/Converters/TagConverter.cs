using Server.Data.Classes;
using Server.Models;

namespace Server.BusinessLogic.Converters
{
    public class TagConverter : IModelEntityConverter<TagModel, Tag>
    {
        public Tag GetEntityByModel(TagModel model)
        {
            if (model == null) return null;
            return new Tag
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public TagModel GetModelByEntity(Tag entity)
        {
            if (entity == null) return null;
            return new TagModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
