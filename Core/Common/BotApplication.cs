namespace EasyChatGptBot;

public abstract class BotApplication : IBotApplication, IAddMsg<IBotMsg>
{
    protected List<Func<IBotMsg, Func<Task>, Task>> MiddleWares;
    protected readonly IMsgPipeline pipeline;

    protected BotApplication(IMsgPipeline pipeline)
    {
        MiddleWares = new();
        this.pipeline = pipeline;
    }

    /// <summary>
    /// 创建builder
    /// </summary>
    public static BotApplicationBuilder CreateBuilder()
    {
        return new BotApplicationBuilder();
    }

    /// <summary>
    /// 添加消息
    /// </summary>
    public virtual void AddMsg(IBotMsg msg)
    {
        pipeline.AddMsg(msg);
    }

    /// <summary>
    /// 获取消息
    /// </summary>
    public virtual IBotMsg GetMsg()
    {
        return pipeline.GetMsg();
    }
    /// <summary>
    /// 获取消息
    /// </summary>
    public virtual async Task<IBotMsg> GetMsgAsync()
    {
        return await pipeline.GetMsgAsync();
    }

    /// <summary>
    /// TODO 添加中间件
    /// </summary>
    public IBotApplication Use(Func<IBotMsg, Func<Task>, Task> middleware)
    {
        return this;
    }
    public abstract Task RunAsync();
}