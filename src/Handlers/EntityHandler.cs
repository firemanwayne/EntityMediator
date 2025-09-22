namespace EntityMediator.Handlers;

internal sealed class EntityHandler(
    IErrorHandler errorHandler,
    IEntityMediator entityManager,
    IServiceScopeFactory factory) : IEntityHandler
{
    bool HasHandlers;
    IHandler? _objectHandler;
    HashSet<HandlerType> _handlers = [];

    public async Task HandleAsync<T>(T entity)
    {
        try
        {
            ConsoleEx.WriteLineYellow("Searching for registered handlers...");

            var entityTypeName = typeof(T).Name;

            HasHandlers = entityManager.HasHandlerFor<T>();

            if (HasHandlers)
            {
                var entityType = entityManager.GetEntityType(entityTypeName);

                if (entityType is not null)
                {
                    ConsoleEx.WriteLineGreen("Handlers found!");

                    _handlers = [.. entityManager.GetHandlersFor<T>()];

                    foreach (var handler in _handlers)
                    {
                        _objectHandler = factory
                            .CreateScope()
                            .ServiceProvider
                            .GetRequiredService(handler.Handler) as IHandler;

                        if (_objectHandler is null)
                        {
                            continue;
                        }

                        await ExecuteHandler(entity);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ConsoleEx.WriteLineRed(ex.Message);

            errorHandler.Publish(ex, LogLevel.Error);
        }
    }

    async Task ExecuteHandler<T>(T entity)
    {
        ConsoleEx.WriteLineYellow("Committing to storage...");

        if (_objectHandler is not null)
        {
            Type handlerType = _objectHandler.GetType();

            MethodInfo? handleMethod = handlerType
                .GetMethods()
                .FirstOrDefault(e => e.Name.Equals(nameof(IHandler.HandleAsync)));

            if (handleMethod is not null && _objectHandler is not null)
            {
                await (Task)handleMethod.Invoke(_objectHandler, [entity])!;

                ConsoleEx.WriteLineGreen("Data Committed!");
            }
        }
    }
}
