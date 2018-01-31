namespace Server.BusinessLogic.Converters
{
    public interface IModelEntityConverter<TM, TE>
    {
        TM GetModelByEntity(TE entity);
        TE GetEntityByModel(TM model);
    }
}
