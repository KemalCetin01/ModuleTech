using Microsoft.Extensions.Options;
using StackExchange.Redis;


namespace ModuleTech.Core.Caching.Helper;

public class RedisServer : IRedisServer
{
    public RedisServer(IOptions<RedisOption> redisOption)
    {
        var opt = redisOption.Value;
        var configOptions = ConfigurationOptions.Parse(opt.Server);
        if (!string.IsNullOrEmpty(opt.Password))
            configOptions.Password = opt.Password;

        Database = ConnectionMultiplexer
            .Connect(configOptions)
            .GetDatabase(opt.DatabaseId);
    }
    public IDatabase Database { get; }
}
