namespace EasyChatGptBot;

public interface IBotApplication
{
    IBotApplication Use<T>() where T : class, IMiddleware;
    IBotApplication Use(Func<IBotMsg, Func<Task>, Task> middleware);
}