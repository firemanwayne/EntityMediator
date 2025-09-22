namespace EntityMediator.Interfaces;

public interface IHandler
{
    Task HandleAsync<T>(T entity);
}
