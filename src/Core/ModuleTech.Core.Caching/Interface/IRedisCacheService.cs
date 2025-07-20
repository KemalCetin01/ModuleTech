using StackExchange.Redis;

namespace ModuleTech.Core.Caching.Interface;

public interface IRedisCacheService : ICacheProvider
{
    bool Set(string key, string data);
    Task<bool> SetAsync(string key, string data, CancellationToken cancellationToken = default);
    bool SetAs<TData>(string key, TData data);
    Task<bool> SetAsAsync<TData>(string key, TData data, CancellationToken cancellationToken = default);
    Task<bool> HashSetAsync(string key, string hashField, string data, CancellationToken cancellationToken = default);

    Task<bool> HashSetAsAsync<TData>(string key, string hashField, TData data,
        CancellationToken cancellationToken = default);

    Task<bool> HashDeleteAsync(string key, string hashField, CancellationToken cancellationToken = default);
    Task<RedisValue> HashGetAsync(string key, string hashField, CancellationToken cancellationToken = default);
    Task<TData?> HashGetAsAsync<TData>(string key, string hashField, CancellationToken cancellationToken = default);
    Task<HashEntry[]> GetHashEntriesAsync(string key, CancellationToken cancellationToken = default);
}