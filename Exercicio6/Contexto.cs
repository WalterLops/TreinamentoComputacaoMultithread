namespace Exercicio6;

public class Contexto : IDisposable
{
    private static Dictionary<int, Contexto> _map = new();
    private Dictionary<string, object> _hanger = new();
    public Contexto()
    {
        lock(_map)
            _map.Add(Thread.CurrentThread.ManagedThreadId, this);
    }
    public void Add(string name, object value)
    {
        _hanger[name] = value;
    }
    public void Remove(string name)
    {
        if (_hanger.ContainsKey(name))
            _hanger.Remove(name);
    }
    public static Contexto Get()
    {
        lock (_map)
            return _map[Thread.CurrentThread.ManagedThreadId];
    }
    public object? Get(string name)
    {
        return _hanger.GetValueOrDefault(name);
    }
    public void Dispose()
    {
        lock (_map)
            _map.Remove(Thread.CurrentThread.ManagedThreadId);
    }
}