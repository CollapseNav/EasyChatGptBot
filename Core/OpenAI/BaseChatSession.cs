using System.Net.Http.Json;
using Collapsenav.Net.Tool;

namespace EasyChatGptBot;
public class BaseChatSession : IOpenAiChatSession
{
    private readonly OpenAIConfig config;
    private readonly HttpClient client;
    protected string AiContent = string.Empty;

    public BaseChatSession(OpenAIConfig config, HttpClient client)
    {
        this.config = config;
        this.client = client;
        History = new Queue<OpenAIChatUnit>();
    }

    public Queue<OpenAIChatUnit> History { get; protected set; }
    /// <summary>
    /// TODO 记录上下文
    /// </summary>
    public async Task<string> AskAsync(string question)
    {
        var curr = new OpenAIChatUnit(OpenAIRoleEnum.user.ToString(), question);
        var history = History.ToList();
        history.Add(curr);
        var request = new HttpRequestMessage(HttpMethod.Post, config.ChatApiUrl)
        {
            Headers = {
                {"Authorization", $"Bearer {config.ApiKey}"}
            },
            Content = JsonContent.Create(new
            {
                model = config.GptModel,
                max_tokens = config.MaxLen,
                messages = history,
                temperature = config.Temperature,
            })
        };
        var response = await client.SendAsync(request);
        var res = await response.Content.ReadFromJsonAsync<OpenAiChatResult>();
        // 错误处理
        if (res == null)
            return "请求失败，OpenAI无响应";
        if (res.Error != null)
            return $"Api响应错误：{res.Error.Message}";
        if (res.Choices.IsEmpty() || res.Choices.FirstOrDefault().Message == null)
            return "Api响应无内容";
        // 响应成功
        var result = res?.Choices?.FirstOrDefault()?.Message?.Content;
        var currRes = new OpenAIChatUnit(OpenAIRoleEnum.assistant.ToString(), result);
        // 成功响应之后将本次对话加入历史记录
        History.Enqueue(curr);
        History.Enqueue(currRes);
        return result;
    }
    public virtual void Reset() => History.Clear();
    public void SetContent(string text) => AiContent = text;
}