namespace EasyChatGptBot;

public interface IBotApplication
{
    IBotApplication Use(Func<IBotMsg, Func<Task>, Task> middleware);
}