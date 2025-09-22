namespace EntityMediator.Models;

public class HandlerType
{
    public string Name { get; }
    public Type Handler { get; }

    private HandlerType(Type handler)
    {
        Handler = handler;
        Name = handler.Name;
    }

    public static HandlerType Instance(Type Handler) => new(Handler);
}