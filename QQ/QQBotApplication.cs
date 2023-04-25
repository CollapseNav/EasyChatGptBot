namespace EasyChatGptBot;
public class QQBotApplication : BotApplication
{
    public override async Task RunAsync()
    {
        while (true)
            await Task.Delay(2333);
    }
}