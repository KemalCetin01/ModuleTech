using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Infrastructure.Clients.Keycloak;
using ModuleTech.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleTech.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddKeycloakServices();
        serviceCollection.AddScoped<IIdentityBusinessUserService, IdentityKeycloakBusinessUserService>();
        serviceCollection.AddScoped<IIdentityEmployeeService, IdentityKeycloakEmployeeService>();
    }
}
