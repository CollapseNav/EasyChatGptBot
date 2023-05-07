namespace EasyChatGptBot;
/// <summary>
/// bot消息
/// </summary>
public abstract class BotMsg : IBotMsg
{
    public string? Msg { get; protected set; }
    public abstract void Response(string content);
}
public abstract class BotMsg<T> : BotMsg, IBotMsg<T>
{
    public T? From { get; protected set; }
    public T[]? To { get; protected set; }
}