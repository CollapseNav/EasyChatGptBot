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

    public static BotApplicationBuilder AddJsonConfig<T>(this BotApplicationBuilder builder, string nodePath)
    {
        builder.AddAction((application, container) =>
        {
            var configuration = container.GetObj<SimpleJsonConfiguration>();
            builder.Add(new Config<T>(configuration, nodePath));
        });
        return builder;
    }

    public static BotApplicationBuilder AddAppConfig(this BotApplicationBuilder builder, string path, bool reloadOnChanage = true)
    {
        builder.Add(new SimpleJsonConfiguration(path, reloadOnChanage));
        builder.AddType<OpenAIConfig>();
        builder.AddType<OpenAIChatConfig>();
        return builder;
    }
}