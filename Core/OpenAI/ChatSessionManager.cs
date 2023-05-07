namespace EasyChatGptBot;

public class ChatSessionManager<T>
{
    private readonly OpenAIConfig config;
    protected Dictionary<T, IOpenAiChatSession> Sessions;

    public ChatSessionManager(OpenAIConfig config)
    {
        Sessions = new();
        this.config = config;
    }


    public IOpenAiChatSession GetDefault()
    {
        return new BaseChatSession(config);
    }
}