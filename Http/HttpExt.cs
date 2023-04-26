using System.Net;
using Collapsenav.Net.Tool;

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
        builder.Add(new HttpBotApplication());
        return builder;
    }
}