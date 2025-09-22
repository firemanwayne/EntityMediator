namespace EntityMediator.Managers;

internal class EntityManager : IEntityMediator
{
    private readonly ConcurrentDictionary<string, EntityHandlerRegister> _entityHandlers;

    public EntityManager()
    {
        _entityHandlers = new ConcurrentDictionary<string, EntityHandlerRegister>();
    }

    public void Clear() => _entityHandlers.Clear();

    public bool IsEmpty { get => _entityHandlers.Keys.Count <= 0; }

    public void RegisterEntity<TEntity, TImplementation>() where TImplementation : IHandler
    {
        var HandlerRegister = EntityHandlerRegister.Instance(EntityType.Instance(typeof(TEntity)));

        HandlerRegister.AddHandler(HandlerType.Instance(typeof(TImplementation)));

        _entityHandlers.AddOrUpdate(HandlerRegister.Name, HandlerRegister, (k, v) => HandlerRegister);

        Console.WriteLine($"Registered Data Model {HandlerRegister.Name} to Entity Manager with {typeof(TImplementation).Name}");
    }

    public bool HasHandlerFor<T>()
    {
        var key = typeof(T).Name;

        return _entityHandlers.ContainsKey(key);
    }

    public bool HasHandlerFor(string name)
    {
        return _entityHandlers.ContainsKey(name);
    }

    public IEnumerable<HandlerType> GetHandlersFor<T>()
    {
        var key = typeof(T).Name;

        return _entityHandlers[key].Handlers;
    }

    public EntityType? GetEntityType(string name)
    {
        return _entityHandlers.TryGetValue(name, out EntityHandlerRegister? value) ? value.Entity : null;
    }
}
