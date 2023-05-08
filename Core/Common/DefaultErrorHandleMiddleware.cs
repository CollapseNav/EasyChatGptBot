namespace EasyChatGptBot;

public class DefaultErrorHandleMiddleware : IMiddleware
{
    public async Task Invoke(IBotMsg botMsg, Func<Task> next)
    {
        try
        {
            await next();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            botMsg.Response(ex.Message);
        }
    }
}