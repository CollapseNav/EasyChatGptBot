using Collapsenav.Net.Tool;

namespace EasyChatGptBot;
public class BaseChatMiddleware<T> : IMiddleware where T : IChatSessionKey
{
    protected OpenAIConfig AIConfig;
    private readonly ChatSessionManager<T> manager;

    public BaseChatMiddleware(OpenAIConfig aIConfig, ChatSessionManager<T> manager)
    {
        AIConfig = aIConfig;
        this.manager = manager;
    }

    public async Task Invoke(IBotMsg botMsg, Func<Task> next)
    {
        string content = await manager.GetSessionByBotMsg(botMsg).AskAsync(botMsg.Msg);
        if (content.NotEmpty())
            botMsg.Response(content);
    }
}