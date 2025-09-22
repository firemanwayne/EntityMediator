namespace EntityMediator.Models;

public class EntityType
{
    public string Name { get; }
    public Type Entity { get; }

    private EntityType(Type entity)
    {
       Entity = entity;
        Name = entity.Name;
    }

    public static EntityType Instance(Type EntityType) => new(EntityType);
}