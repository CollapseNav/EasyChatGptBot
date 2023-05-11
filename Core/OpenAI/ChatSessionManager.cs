namespace EasyChatGptBot;

public class ChatSessionManager<T> where T : IChatSessionKey
{
    private readonly IConfig<OpenAIConfig> config;
    private readonly HttpClient client;
    protected Dictionary<T, IOpenAiChatSession> Sessions;

    public ChatSessionManager(IConfig<OpenAIConfig> config, HttpClient client)
    {
        Sessions = new();
        this.config = config;
        this.client = client;
    }

    public bool HasSession(T key)
    {
        return Sessions.ContainsKey(key);
    }

    public IOpenAiChatSession GetSession(T key)
    {
        if (!HasSession(key))
            Sessions.Add(key, new BaseChatSession(config.Data, client));
        return Sessions[key];
    }

    public IOpenAiChatSession GetSessionByBotMsg(IBotMsg botMsg)
    {
        if (botMsg is IBotMsg<T> chatBotMsg)
            return GetSession(chatBotMsg.From);
        throw new Exception("错误的对象结构");
    }
}