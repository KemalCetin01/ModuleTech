using Microsoft.Extensions.DependencyInjection;
using ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
using ModuleTech.Infrastructure.Clients.Keycloak.Services;

namespace ModuleTech.Infrastructure.Clients.Keycloak;

public static class ServiceExtensions
{
    public static void AddKeycloakServices(this IServiceCollection serviceCollection)
    {        
        serviceCollection.AddScoped<IKeycloakTokenService, KeycloakBaseService>();
        serviceCollection.AddScoped<IKeycloakUserService, KeycloakUserService>();
        serviceCollection.AddScoped<IKeycloakRoleService, KeycloakRoleService>();
        serviceCollection.AddScoped<IKeycloakRoleMappingService, KeycloakRoleMappingService>();
        serviceCollection.AddScoped<IKeycloakClientService, KeycloakClientService>();
        serviceCollection.AddScoped<IKeycloakAccountService, KeycloakAccountService>();
    }
}
