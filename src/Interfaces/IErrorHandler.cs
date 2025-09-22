namespace EntityMediator.Interfaces;

public interface IErrorHandler
{
    void Publish(Exception ex, LogLevel loglevel);
}
