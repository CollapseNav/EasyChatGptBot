using Collapsenav.Net.Tool;

namespace EasyChatGptBot;
public class BaseChatMiddleware : IMiddleware
{
    protected OpenAIConfig AIConfig;
    private readonly ChatSessionManager<int> manager;

    public BaseChatMiddleware(OpenAIConfig aIConfig, ChatSessionManager<int> manager)
    {
        AIConfig = aIConfig;
        this.manager = manager;
    }

    public async Task Invoke(IBotMsg botMsg, Func<Task> next)
    {
        string content = await manager.GetDefault().AskAsync(botMsg.Msg);
        if (content.NotEmpty())
            botMsg.Response(content);
    }
}