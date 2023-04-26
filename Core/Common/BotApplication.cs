using System.Collections.Concurrent;
using Collapsenav.Net.Tool;

namespace EasyChatGptBot;

public abstract class BotApplication : IBotApplication, IAddMsg<IBotMsg>
{
    protected BotApplication()
    {
        Msgs = new();
    }

    protected ConcurrentQueue<IBotMsg> Msgs { get; set; }
    public static BotApplicationBuilder CreateBuilder()
    {
        return new BotApplicationBuilder();
    }

    /// <summary>
    /// 添加消息
    /// </summary>
    public void AddMsg(IBotMsg msg)
    {
        Msgs.Enqueue(msg);
    }
    /// <summary>
    /// TODO 添加中间件
    /// </summary>
    public IBotApplication Use(Func<IBotMsg, IBotMsg> middleware)
    {
        return this;
    }
    public abstract Task RunAsync();
}