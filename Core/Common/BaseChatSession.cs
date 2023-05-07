using System.Net.Http.Json;

namespace EasyChatGptBot;
public class BaseChatSession : IOpenAiChatSession
{
    private readonly OpenAIConfig config;
    protected string AiContent = string.Empty;

    public BaseChatSession(OpenAIConfig config)
    {
        this.config = config;
    }

    public Queue<KeyValuePair<string, string>> History { get; protected set; }
    /// <summary>
    /// TODO 记录上下文
    /// </summary>
    public async Task<string> AskAsync(string question)
    {
        List<OpenAIChatUnit> messages = new();
        messages.Add(new OpenAIChatUnit("user", question));
        var request = new HttpRequestMessage(HttpMethod.Post, config.ChatApiUrl)
        {
            Headers = {
                {"Authorization", $"Bearer {config.ApiKey}"}
            },
            Content = JsonContent.Create(new
            {
                model = config.GptModel,
                max_tokens = config.MaxLen,
                messages = messages,
                temperature = config.Temperature,
            })
        };
        var client = new HttpClient();
        var response = await client.SendAsync(request);
        var davinci_rst = await response.Content.ReadFromJsonAsync<davinci_result>();
        return davinci_rst?.choices?.FirstOrDefault()?.message?.content;
    }
    public virtual void Reset() => History.Clear();
    public void SetContent(string text) => AiContent = text;
}