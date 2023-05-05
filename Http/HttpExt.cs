using System.Net;

namespace EasyChatGptBot;

public static class HttpExt
{
    public static BotApplicationBuilder AddHttpBot(this BotApplicationBuilder builder, string listen)
    {
        builder.AddAction(async (application, container) =>
        {
            if (!listen.EndsWith("/"))
                listen += "/";
            HttpListener listener = new();
            listener.Prefixes.Add(listen);
            listener.Start();
            while (true)
            {
                var context = await listener.GetContextAsync();
                var botMsg = new HttpMsg(context);
                application.AddMsg(botMsg);
            }
        });
        builder.AddType<HttpBotApplication>();
        builder.AddType<MsgPipeLine>();
        return builder;
    }
}