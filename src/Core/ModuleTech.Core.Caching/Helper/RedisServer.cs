using Microsoft.Extensions.Options;
using StackExchange.Redis;


namespace ModuleTech.Core.Caching.Helper;

public class RedisServer : IRedisServer
{
    public RedisServer(IOptions<RedisOption> redisOption)
    {
         Database=ConnectionMultiplexer
             .Connect(redisOption.Value.Server)
             .GetDatabase(redisOption.Value.DatabaseId);
    }
    public IDatabase Database { get; }
}
