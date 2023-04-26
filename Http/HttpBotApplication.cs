namespace EasyChatGptBot;

public class HttpBotApplication : BotApplication, IAddMsg<HttpMsg>
{
    public void AddMsg(HttpMsg msg)
    {
        Msgs.Enqueue(msg);
    }

    public override async Task RunAsync()
    {
        while (true)
            await Task.Delay(2333);
    }
}