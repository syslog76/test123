using System.Runtime.Caching;

namespace lang.Repository;

public enum CacheType
{
    Default = 0,
    ExtendOnAccess = 1,
    DictionaryCache = 2,
}

public class MilMemoryCache<T> : IMilCache<T> where T : class
{
    private readonly CacheType _type;
    private readonly int _expireSeconds;
    private readonly MemoryCache _memoryCache;
    public string Name { get; }

    public MilMemoryCache(string name, int expireSeconds = 300, CacheType type = CacheType.Default)
    {
        Name = name;
        _type = type;
        _expireSeconds = expireSeconds;
        _memoryCache = new MemoryCache(Name);
    }

    public bool TryGet(string key, out T? result)
    {
        result = _memoryCache.Get(key) as T;
        return result != null;
    }

    public T GetOrCalculate(string key, Func<T> valueProvider)
    {
        if (_memoryCache.Get(key) is T result) 
            return result;

        result = valueProvider.Invoke();
        _memoryCache.Add(key, result, CreateCacheItemPolicy());

        return result;
    }

    public IEnumerable<KeyValuePair<string, object>> AsEnumerable() => _memoryCache.AsEnumerable();
    private CacheItemPolicy CreateCacheItemPolicy()
    {
        var result = new CacheItemPolicy();

        switch (_type)
        {
            case CacheType.Default:
            case CacheType.DictionaryCache:
                result.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(2 * _expireSeconds);
                break;
            case CacheType.ExtendOnAccess:
                result.SlidingExpiration = TimeSpan.FromSeconds(_expireSeconds);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return result;
    }

    public void Put(string key, T current) => _memoryCache.Set(key, current, CreateCacheItemPolicy());

    public void ClearCache()
    {
        _memoryCache.Select(kvp => kvp.Key).ToList().ForEach(key => _memoryCache.Remove(key));
    }
    public T GenerateCacheKey<T>(Func<T> predicate) => predicate();

    public void Dispose()
    {
        _memoryCache.Dispose();
    }
}
