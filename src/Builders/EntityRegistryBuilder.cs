namespace EntityMediator.Builders;

public sealed class EntityRegistryBuilder
{
    readonly IEntityMediator _entityManager;

    public EntityRegistryBuilder(IHost app)
    {
        _entityManager = app.Services.GetRequiredService<IEntityMediator>();
    }

    public EntityRegistryBuilder(IApplicationBuilder app)
    {
        _entityManager = app.ApplicationServices.GetRequiredService<IEntityMediator>();
    }

    public EntityRegistryBuilder RegisterEntityAndHandler<TEntity, THandler>() where THandler : IHandler
    {
        _entityManager.RegisterEntity<TEntity, THandler>();

        return this;
    }
}
