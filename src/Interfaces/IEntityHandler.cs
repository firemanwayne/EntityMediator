namespace EntityMediator.Interfaces;

public interface IEntityHandler
{
    Task HandleAsync<T>(T message);
}