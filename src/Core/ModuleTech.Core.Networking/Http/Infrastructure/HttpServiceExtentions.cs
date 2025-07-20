using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using ModuleTech.Core.Networking.Http.Services;

namespace ModuleTech.Core.Networking.Http.Infrastructure;

public static class HttpServiceExtentions
{
    public static IHttpClientBuilder AddHttpService<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this IServiceCollection services) where TClient : HttpService
    {
        services.AddTransient<HttpServiceMiddleware>();
        return services.AddHttpClient<TClient>()
            .AddHttpMessageHandler<HttpServiceMiddleware>();
    }
}