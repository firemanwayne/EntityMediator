namespace EntityMediator;

using Microsoft.Extensions.Hosting;

public static class ServiceRegistryExtenstions
{
    public static EntityMediatorBuilder AddEntityMediator(this IServiceCollection services)
    {
        return new EntityMediatorBuilder(services);
    }

    public static EntityRegistryBuilder AddEntityMediator(this IApplicationBuilder app)
    {
        return new EntityRegistryBuilder(app);
    }

    public static EntityRegistryBuilder AddEntityMediator(this IHost app)
    {
        return new EntityRegistryBuilder(app);
    }
}
