using EasyChatGptBot;

var builder = BotApplication.CreateBuilder();
builder.AddQQBot("ws://localhost:8080")
;
var app = builder.Build();

await app.RunAsync();