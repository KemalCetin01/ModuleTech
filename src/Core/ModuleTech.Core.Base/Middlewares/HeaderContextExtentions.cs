using ModuleTech.Core.Base.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleTech.Core.Base.Middlewares;

public static class HeaderContextExtentions
{
    public static IApplicationBuilder AddHeaderContextMiddleware(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseMiddleware<HeaderContextMiddleware>();

        return appBuilder;
    }

    public static void AddHeaderContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<HeaderContext>();
    }
}