namespace EasyChatGptBot;

public interface IBotApplication
{
    /// <summary>
    /// 使用中间件
    /// </summary>
    IBotApplication Use<T>() where T : class, IMiddleware;
    /// <summary>
    /// 使用中间件
    /// </summary>
    IBotApplication Use(Func<IBotMsg, Func<Task>, Task> middleware);
    Task RunAsync();
    void AddMsg(IBotMsg msg);
    IBotMsg GetMsg();
    Task<IBotMsg> GetMsgAsync();
}