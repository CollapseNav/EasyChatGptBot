using EasyChatGptBot;
var builder = BotApplication.CreateBuilder();
builder
.AddAppConfig($"AppConfig.json", true)
.AddJsonConfig<OpenAIChatConfig>("ChatConfig")
.AddJsonConfig<OpenAIConfig>("OpenAIConfig")
// .AddQQBot("ws://localhost:8080")
.AddHttpBot("http://localhost:8080/")
.AddType<ChatSessionManager<HttpSimpleUser>>()
.Add(new HttpClient())
;
var app = builder.Build();
app.Use<DefaultErrorHandleMiddleware>();
app.Use<BaseChatMiddleware<HttpSimpleUser>>();
await app.RunAsync();
