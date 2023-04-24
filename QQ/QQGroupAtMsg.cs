using System.Data;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;

namespace EasyChatGptBot;

/// <summary>
/// qq群at消息
/// </summary>
public class QQGroupAtMsg : BotMsg<QQSimpleUser>
{
    public QQGroupAtMsg() { }

    public QQGroupAtMsg(CqGroupMessagePostContext context)
    {
        InitMsg(this, context);
    }
    /// <summary>
    /// 通过context创建消息
    /// </summary>
    public static QQGroupAtMsg CreateMsg(CqGroupMessagePostContext context)
    {
        return InitMsg(new QQGroupAtMsg(), context);
    }
    /// <summary>
    /// 通过context初始化群at消息
    /// </summary>
    public static QQGroupAtMsg InitMsg(QQGroupAtMsg botMsg, CqGroupMessagePostContext context)
    {
        if (botMsg == null || context == null)
            throw new NoNullAllowedException();
        var msg = context.Message;
        botMsg.Msg = msg.Text.Trim();
        botMsg.To = msg.Where(item => item is CqAtMsg).Select(item =>
        {
            var at = (item as CqAtMsg)!;
            return new QQSimpleUser(at.Target, at.Name);
        }).ToArray();
        botMsg.From = new QQSimpleUser(context.UserId, context?.Sender?.Nickname);
        return botMsg;
    }
}