using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModuleTech.Core.Logging.Enrich;
using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Formatting.Json;

namespace ModuleTech.Core.Logging;

public static class ServiceRegistration
{
    public static WebApplicationBuilder UseSerilogLogging(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<CorrelationIdEnricher>();

        builder.Logging.ClearProviders();
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;


        builder.Host.UseSerilog((_, serviceProvider, config) =>
        {
            var httpContext = serviceProvider.GetRequiredService<CorrelationIdEnricher>();

            config
                .Enrich.With(httpContext)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("environment", environment)
                .Enrich.WithCorrelationIdHeader("CorrelationId")
                .WriteTo.Console(new ElasticsearchJsonFormatter())
                .WriteTo.File(
                    new JsonFormatter(),
                    path: "Logs/log-.json", // Uygulama kökünde Logs klasörüne yazar
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    fileSizeLimitBytes: 10_000_000,
                    rollOnFileSizeLimit: true,
                    shared: true)
                .ReadFrom.Configuration(configuration);
        });
        return builder;
    }
}
