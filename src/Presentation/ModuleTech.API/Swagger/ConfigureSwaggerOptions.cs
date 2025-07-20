using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ModuleTech.API.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            // Her versiyon için Swagger dökümaný oluþtur
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }

            // JWT Authentication için sabit "Bearer" tanýmý
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            // XML yorumlarýný ekle
            var basePath = AppContext.BaseDirectory;
            var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            var fileName = System.IO.Path.GetFileName(assemblyName + ".xml");
            options.IncludeXmlComments(System.IO.Path.Combine(basePath, fileName));
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Identity API",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " - DEPRECATED";
            }

            return info;
        }
    }
}
