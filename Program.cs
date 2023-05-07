using EasyChatGptBot;
var builder = BotApplication.CreateBuilder();
builder
// .AddHttpBot("http://localhost:8088")
.AddQQBot("ws://localhost:8080")
.AddOpenAIConfig(new OpenAIConfig(""))
.AddOpenAIChatConfig(new OpenAIChatConfig())
.AddType<ChatSessionManager<int>>()
;
var app = builder.Build();
app.Use<BaseChatMiddleware>();
await app.RunAsync();
