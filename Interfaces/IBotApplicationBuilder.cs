namespace EasyChatGptBot;

public interface IBotApplication
{
    IBotApplication Use(Func<IBotMsg, IBotMsg> middleware);
}