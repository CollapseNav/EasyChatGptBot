namespace EasyChatGptBot;

/// <summary>
/// qq用户
/// </summary>
public class QQSimpleUser
{
    public QQSimpleUser() { }

    public QQSimpleUser(long userId, string? name)
    {
        UserId = userId;
        Name = name;
    }

    /// <summary>
    /// 用户qq号
    /// </summary>
    public long UserId { get; set; }
    /// <summary>
    /// 用户名称
    /// </summary>
    public string? Name { get; set; }
}