using ModuleTech.Core.Caching.Concrete;
using ModuleTech.Core.Caching.Helper;
using ModuleTech.Core.Caching.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleTech.Core.Caching;

public static class ServiceRegistration
{
    public static void AddRedisCache(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<RedisOption>()
            .Configure(options => configuration.GetSection("Redis").Bind(options))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection.AddSingleton<IRedisServer, RedisServer>();
        serviceCollection.AddSingleton<IRedisCacheService, RedisCacheService>();

    }
}
