namespace EasyChatGptBot;
public class QQBotApplication : BotApplication
{
    public QQBotApplication(IMsgPipeline pipeline) : base(pipeline) { }

    public override async Task RunAsync()
    {
        while (true)
            await Task.Delay(2333);
    }
}