namespace EasyChatGptBot;

public static class CommonExt
{
    public static BotApplicationBuilder AddOpenAIConfig(this BotApplicationBuilder builder, OpenAIConfig config)
    {
        return builder.Add(config);
    }

    public static BotApplicationBuilder AddOpenAIChatConfig(this BotApplicationBuilder builder, OpenAIChatConfig config)
    {
        return builder.Add(config);
    }
}