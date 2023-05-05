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

    public ObjContainer AddOrUpdate(Type type, object obj)
    {
        if (obj == null)
            return this;
        if (ObjMap.ContainsKey(type))
            ObjMap[type] = obj;
        else
            ObjMap.Add(type, obj);
        return this;
    }
    public ObjContainer AddOrUpdate<T>(T obj)
    {
        return AddOrUpdate(typeof(T), obj);
    }

    public object GetObj(Type type)
    {
        var keys = ObjMap.Keys.Where(item => item.IsType(type));
        if (keys.Count() > 1)
            throw new Exception($"无法创建 {type.ToString()} 类型的依赖, 容器中匹配到多个适用的类型");
        if (keys.Count() == 1)
            return ObjMap[keys.First()];

        var types = Types.Where(item => item.IsType(type));
        if (types.Count() != 1)
            throw new Exception($"无法创建 {type.ToString()} 类型的依赖, 容器中未注册对应的类型");
        var obj = ConstructObject(types.First());
        if (obj != null)
            AddOrUpdate(type, obj);
        return obj;
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
        var parameterTypes = constructor.GetParameters().Select(item => item.ParameterType).ToArray();
        if (parameterTypes.Any(item => !AllTypes.Any(t => t.IsType(item))))
            throw new Exception("容器中未注册对应的依赖");
        var parameters = parameterTypes.Select(item => GetObj(item)).ToArray();
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