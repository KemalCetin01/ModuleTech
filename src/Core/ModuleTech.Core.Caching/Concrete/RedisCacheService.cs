using ModuleTech.Core.Caching.Helper;
using ModuleTech.Core.Caching.Interface;
using StackExchange.Redis;
using System.Text.Json;

namespace ModuleTech.Core.Caching.Concrete;

public class RedisCacheService : IRedisCacheService
{
    protected readonly IRedisServer RedisServer;

    public RedisCacheService(IRedisServer redisServer)
    {
        RedisServer = redisServer;
    }

    public string? Get(string key)
    {
        return RedisServer.Database.StringGet(key);
    }

    public TData? GetAs<TData>(string key) where TData : class, new()
    {
        var stringData = RedisServer.Database.StringGet(key);
        return stringData.IsNullOrEmpty ? null : JsonSerializer.Deserialize<TData>(stringData!);
    }

    public async Task<string?> GetAsync(string key, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.StringGetAsync(key);
    }

    public async Task<TData?> GetAsAsync<TData>(string key, CancellationToken cancellationToken)
        where TData : class, new()
    {
        var stringData = await RedisServer.Database.StringGetAsync(key);
        return stringData.IsNullOrEmpty ? default : JsonSerializer.Deserialize<TData>(stringData!);
    }

    public bool Set(string key, string data, TimeSpan expireTime)
    {
        return RedisServer.Database.StringSet(key, data, expireTime);
    }

    public bool SetAs<TData>(string key, TData data, TimeSpan expireTime)
    {
        return RedisServer.Database.StringSet(key, JsonSerializer.Serialize(data), expireTime);
    }

    public async Task<bool> SetAsync(string key, string data, TimeSpan expireTime,
        CancellationToken cancellationToken)
    {
        return await RedisServer.Database.StringSetAsync(key, data, expireTime);
    }

    public async Task<bool> SetAsAsync<TData>(string key, TData data, TimeSpan expireTime,
        CancellationToken cancellationToken)
    {
        return await RedisServer.Database.StringSetAsync(key, JsonSerializer.Serialize(data), expireTime);
    }

    public bool Set(string key, string data)
    {
        return RedisServer.Database.StringSet(key, data);
    }

    public async Task<bool> SetAsync(string key, string data, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.StringSetAsync(key, data);
    }

    public bool SetAs<TData>(string key, TData data)
    {
        return RedisServer.Database.StringSet(key, JsonSerializer.Serialize(data));
    }

    public async Task<bool> SetAsAsync<TData>(string key, TData data, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.StringSetAsync(key, JsonSerializer.Serialize(data));
    }

    public bool Remove(string key)
    {
        return RedisServer.Database.KeyDelete(key);
    }

    public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.KeyDeleteAsync(key);
    }

    public void Clear()
    {
        foreach (var server in RedisServer.Database.Multiplexer.GetServers()) server.FlushDatabase();
    }

    public async Task ClearAsync(CancellationToken cancellationToken)
    {
        foreach (var server in RedisServer.Database.Multiplexer.GetServers()) await server.FlushDatabaseAsync();
    }

    public async Task<bool> HashSetAsync(string key, string hashField, string data, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.HashSetAsync(key, hashField, data);
    }

    public async Task<bool> HashSetAsAsync<TData>(string key, string hashField, TData data,
        CancellationToken cancellationToken)
    {
        return await RedisServer.Database.HashSetAsync(key, hashField, JsonSerializer.Serialize(data));
    }

    public async Task<bool> HashDeleteAsync(string key, string hashField, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.HashDeleteAsync(key, hashField);
    }

    public async Task<RedisValue> HashGetAsync(string key, string hashField, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.HashGetAsync(key, hashField);
    }

    public async Task<TData?> HashGetAsAsync<TData>(string key, string hashField, CancellationToken cancellationToken)
    {
        var redisData=await RedisServer.Database.HashGetAsync(key, hashField);
        return redisData.IsNullOrEmpty ? default : JsonSerializer.Deserialize<TData>(redisData!);
    }

    public async Task<HashEntry[]> GetHashEntriesAsync(string key, CancellationToken cancellationToken)
    {
        return await RedisServer.Database.HashGetAllAsync(key);
    }
}