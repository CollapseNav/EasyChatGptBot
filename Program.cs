using EasyChatGptBot;
var builder = BotApplication.CreateBuilder();
builder.AddHttpBot("http://localhost:8080");
var app = builder.Build();
app.Use<HttpEmptyMiddleware>();
await app.RunAsync();