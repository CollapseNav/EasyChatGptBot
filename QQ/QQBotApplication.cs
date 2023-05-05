namespace EasyChatGptBot;
public class QQBotApplication : BotApplication
{
    public QQBotApplication(IMsgPipeline pipeline, ObjContainer container) : base(pipeline, container)
    {
    }

    public override async Task RunAsync()
    {
        while (true)
            await Task.Delay(2333);
    }
}