namespace EntityMediator.Interfaces;

internal interface IEntityMediator
{
    bool IsEmpty { get; }

    void Clear();

    EntityType? GetEntityType(string name);

    bool HasHandlerFor(string name);

    bool HasHandlerFor<T>();

    IEnumerable<HandlerType> GetHandlersFor<T>();

    void RegisterEntity<TEntity, TImplementation>() where TImplementation : IHandler;
}
