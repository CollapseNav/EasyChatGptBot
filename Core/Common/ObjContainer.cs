using Collapsenav.Net.Tool;

namespace EasyChatGptBot;

/// <summary>
/// 一个简单的 对象容器
/// </summary>
public class ObjContainer
{
    public ObjContainer()
    {
        ObjMap = new();
        Types = new();
    }

    public Dictionary<Type, object> ObjMap { get; set; }
    public List<Type> Types { get; set; }

    public List<Type> AllTypes { get => ObjMap.Keys.Concat(Types).Unique().ToList(); }

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

    public object GetObj(Type type)
    {
        var keys = ObjMap.Keys.Where(item => item.IsType(type));
        if (keys.Count() > 1)
            throw new Exception();
        if (keys.Count() == 1)
            return ObjMap[keys.First()];

        var types = Types.Where(item => item.IsType(type));
        if (types.Count() != 1)
            throw new Exception();
        return ConstructObject(types.First());
    }
    public T GetObj<T>() where T : class
    {
        return (GetObj(typeof(T)) as T)!;
    }

    public object ConstructObject(Type type)
    {
        var cons = type.GetConstructors();
        if (cons.Any(item => item.GetParameters().Length == 0))
            return Activator.CreateInstance(type)!;
        var constructor = cons.First();

        var parameterTypes = constructor.GetParameters();
        if (parameterTypes.Select(item => item.ParameterType).Any(item => AllTypes.Any(t => item.IsType(t))))
            throw new Exception();
        var parameters = parameterTypes.Select(item => GetObj(item.ParameterType)).ToArray();
        return Activator.CreateInstance(type, parameters)!;
    }
    public ObjContainer AddType<T>()
    {
        if (Types.Contains(typeof(T)))
            return this;
        Types.Add(typeof(T));
        return this;
    }
}