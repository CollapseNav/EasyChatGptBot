using Collapsenav.Net.Tool;

namespace EasyChatGptBot;

public class HttpBotApplication : BotApplication
{
    public HttpBotApplication(IMsgPipeline pipeline) : base(pipeline) { }

    public override async Task RunAsync()
    {
        while (true)
        {
            var msg = await pipeline.GetMsgAsync() as HttpMsg;
            Console.WriteLine(msg.ToJson());
            msg.Response(msg.ToJson());
        }
    }
}