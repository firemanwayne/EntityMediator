namespace EntityMediator.Builders;

public sealed class EntityMediatorBuilder
{
    readonly IServiceCollection _services;

    public EntityMediatorBuilder(IServiceCollection services)
    {
        _services = services;

        _services.AddSingleton<IEntityMediator, EntityManager>();
        _services.AddSingleton<IEntityHandler, EntityHandler>();
    }

    public EntityMediatorBuilder AddErrorHandler<TImplementation>() where TImplementation : IErrorHandler
    {
        _services.AddSingleton(typeof(IErrorHandler), typeof(TImplementation));

        return this;
    }
}