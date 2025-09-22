namespace EntityMediator.Handlers;

internal sealed class EntityHandlerRegister(EntityType entity)
{
    public string Name { get; } = entity.Name;

    public EntityType Entity { get; } = entity;

    public IList<HandlerType> Handlers { get; } = [];

    public void AddHandler(HandlerType Handler)
    {
        if (!Handlers.Contains(Handler))
        {
            Handlers.Add(Handler);
        }
    }

    public static EntityHandlerRegister Instance(EntityType Entity) => new(Entity);
}