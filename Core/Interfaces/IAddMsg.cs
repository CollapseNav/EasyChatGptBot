namespace EasyChatGptBot;
public interface IAddMsg<in Msg> where Msg : IBotMsg
{
    void AddMsg(Msg msg);
}