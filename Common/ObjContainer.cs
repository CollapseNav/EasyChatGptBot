using Collapsenav.Net.Tool;

namespace EasyChatGptBot;

/// <summary>
/// 一个简单的 对象容器
/// </summary>
public class ObjContainer
{
    public ObjContainer()
    {
        ObjMap = new Dictionary<Type, object>();
    }

    public Dictionary<Type, object> ObjMap { get; set; }

    public ObjContainer AddOrUpdate<T>(T obj)
    {
        if (obj == null)
            return this;
        if (ObjMap.ContainsKey(typeof(T)))
            ObjMap[typeof(T)] = obj;
        else
            ObjMap.Add(typeof(T), obj);
        return this;
    }

    public T GetObj<T>() where T : class
    {
        var keys = ObjMap.Keys.Where(item => item.IsType(typeof(T)));
        if (keys.IsEmpty())
            throw new Exception();
        if (keys.Count() > 1)
            throw new Exception();
        return (ObjMap[keys.First()] as T)!;
    }
}