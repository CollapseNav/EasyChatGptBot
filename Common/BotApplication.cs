using Collapsenav.Net.Tool;

namespace EasyChatGptBot;

public abstract class BotApplication : IBotApplication
{
    public static BotApplicationBuilder CreateBuilder()
    {
        return new BotApplicationBuilder();
    }

    /// <summary>
    /// 添加消息
    /// </summary>
    public async Task AddMsgAsync(IBotMsg msg)
    {
        await Console.Out.WriteLineAsync(msg.ToJson());
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