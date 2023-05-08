using EasyChatGptBot;
var builder = BotApplication.CreateBuilder();
builder
.AddHttpBot("http://localhost:8080/")
// .AddQQBot("ws://localhost:8080")
.AddOpenAIConfig(new OpenAIConfig(""))
.AddOpenAIChatConfig(new OpenAIChatConfig())
.AddType<ChatSessionManager<HttpSimpleUser>>()
;
var app = builder.Build();
app.Use<DefaultErrorHandleMiddleware>();
app.Use<BaseChatMiddleware<HttpSimpleUser>>();
await app.RunAsync();
