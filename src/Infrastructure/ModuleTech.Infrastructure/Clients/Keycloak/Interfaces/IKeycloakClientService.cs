using ModuleTech.Core.Base.IoC;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
public interface IKeycloakClientService : IScopedService
{
    Task<List<ClientPermissionModel>> GetPermissionsAsync(string realms, string roleName, CancellationToken cancellationToken = default);
}
