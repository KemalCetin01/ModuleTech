using ModuleTech.API.CustomProviders;
using ModuleTech.API.Swagger;
using ModuleTech.Application;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Middlewares;
using ModuleTech.Core.Caching;
using ModuleTech.Core.ExceptionHandling;
using ModuleTech.Core.Logging;
using ModuleTech.Core.Networking.Http.Infrastructure;
using ModuleTech.Infrastructure;
using ModuleTech.Infrastructure.Clients.Keycloak.Services;
using ModuleTech.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using ModuleTech.API.CustomProviders;
using ModuleTech.API.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);


var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = builder.Configuration;

configuration
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{env}.json", true, true)
    .Build();

builder.Services.AddOptions<KeycloakOptions>().BindConfiguration("KeycloakOptions");
builder.Services.AddOptions<OtpOptions>().BindConfiguration("OtpOptions");

builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:8080/realms/ModuleTech";
        options.RequireHttpsMetadata = false; // Geliþtirme ortamýnda HTTPS zorunluluðunu kaldýrýr
        options.Audience = "ms:ModuleTech"; // Client ID
    });

builder.Services.AddAuthorization(); // Bu satýr zaten vardý

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer(configuration);
builder.Services.AddInfrastructureLayer();
builder.Services.AddPersistenceLayer(configuration);
builder.Services.AddRedisCache(configuration);
builder.Services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ErrorResponses = new ApiVersioningErrorResponseProvider();
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});
builder.Services.AddApiLayer(); //RequestBus ve MediatR için gerekli servisleri ekler
builder.Services.AddServices(); //ITransientService ve IScopedService için gerekli servisleri ekler. interfaceye IScoped ekliyse otomatik olarak Scoped olarak ekler. ITransientService ise Transient olarak ekler.
//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHeaderContext();

builder.UseSerilogLogging(configuration); // Serilog


builder.Services.AddHttpService<KeycloakBaseService>();
builder.Services.AddHttpService<KeycloakUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.AddExceptionHandlingMiddleware(true);

app.UseSwagger();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.AddHeaderContextMiddleware();

app.UseSwaggerUI(options =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            description.GroupName.ToUpperInvariant());
    }
});
app.Run();
