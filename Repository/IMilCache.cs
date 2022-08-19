namespace lang.Repository;
public interface IMilCache : IDisposable
{
    public string Name { get; }
    void ClearCache();
}

public interface IMilCache<T> : IMilCache
{
    public void Put(string key, T current);
    public bool TryGet(string key, out T? result);
    public TKey GenerateCacheKey<TKey>(Func<TKey> predicate) => predicate();
    public T GetOrCalculate(string key, Func<T> valueProvider);
    public IEnumerable<KeyValuePair<string, object>> AsEnumerable();
}
