using StackExchange.Redis;

namespace ModuleTech.Core.Caching.Helper;

public interface IRedisServer
{
    public IDatabase Database { get; }
}