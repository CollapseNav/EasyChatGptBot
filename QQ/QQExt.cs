using System.Diagnostics.CodeAnalysis;
using EleCho.GoCqHttpSdk;

namespace EasyChatGptBot;

public static class QQExt
{
    public static BotApplicationBuilder AddQQBot(this BotApplicationBuilder builder, [NotNull] Uri botSocketUri)
    {
        return builder.AddQQBot(options =>
        {
            options.BaseUri = botSocketUri;
            return options;
        });
    }
    public static BotApplicationBuilder AddQQBot(this BotApplicationBuilder builder, [NotNull] string botSocketUri)
    {
        return builder.AddQQBot((options) =>
        {
            options.BaseUri = new Uri(botSocketUri);
            return options;
        });
    }

    public static BotApplicationBuilder AddQQBot(this BotApplicationBuilder builder, Func<CqWsSessionOptions, CqWsSessionOptions> action)
    {
        builder.AddAction(async (application, container) =>
        {
            var option = new CqWsSessionOptions();
            option = action(option);
            CqWsSession session = new(option);
            session.UseGroupMessage(async context =>
            {
                var msg = QQGroupAtMsg.CreateMsg(context);
                await application.AddMsgAsync(msg);
            });
            await session.StartAsync();
            await session.WaitForShutdownAsync();
        });
        builder.Add(new QQBotApplication());
        return builder;
    }
}