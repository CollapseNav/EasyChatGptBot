namespace EasyChatGptBot;
public class QQBotApplication : BotApplication, IAddMsg<QQGroupMsg>
{
    public void AddMsg(QQGroupMsg msg)
    {
        Msgs.Enqueue(msg);
    }

    public override async Task RunAsync()
    {
        while (true)
            await Task.Delay(2333);
    }
}