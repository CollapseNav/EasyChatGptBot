using System.Data;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
namespace EasyChatGptBot;
/// <summary>
/// qq群at消息
/// </summary>
public class QQGroupMsg : BotMsg<QQSimpleUser>
{
    public QQGroupMsg() { }
    public QQGroupMsg(CqGroupMessagePostContext context)
    {
        InitMsg(this, context);
    }
    /// <summary>
    /// 通过context创建消息
    /// </summary>
    public static QQGroupMsg CreateMsg(CqGroupMessagePostContext context)
    {
        return InitMsg(new QQGroupMsg(), context);
    }
    /// <summary>
    /// 通过context初始化群at消息
    /// </summary>
    public static QQGroupMsg InitMsg(QQGroupMsg botMsg, CqGroupMessagePostContext context)
    {
        if (botMsg == null || context == null)
            throw new NoNullAllowedException();
        var msg = context.Message;
        botMsg.Msg = msg.Text.Trim();
        var atmsg = msg.Where(item => item is CqAtMsg).ToList();
        botMsg.To = atmsg.Select(item =>
        {
            var at = (item as CqAtMsg)!;
            return new QQSimpleUser(at.Target, at.Name);
        }).ToArray();
        botMsg.From = new QQSimpleUser(context.UserId, context?.Sender?.Nickname);
        return botMsg;
    }
}