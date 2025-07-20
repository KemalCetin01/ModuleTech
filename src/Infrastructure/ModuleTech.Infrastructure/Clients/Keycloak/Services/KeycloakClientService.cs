using Microsoft.Extensions.Options;
using ModuleTech.Application.Helpers;
using ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;
using static ModuleTech.Application.Constants.Constants;
using ModuleTech.Application.Helpers.Options;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Services;
public class KeycloakClientService : KeycloakBaseService, IKeycloakClientService
{
    private readonly IKeycloakRoleService _keycloakRoleService;
    public KeycloakClientService(IOptions<KeycloakOptions> options, HttpClient client, IKeycloakRoleService keycloakRoleService, string? baseAddress = null, Dictionary<string, string>? requestHeaders = null) : base(options, client, baseAddress, requestHeaders)
    {
        _keycloakRoleService = keycloakRoleService;
        SetRequestHeaders(new Dictionary<string, string> { { "Accept", "application/json" } });
    }



    public async Task<List<ClientPermissionModel>> GetPermissionsAsync(string realm, string roleName, CancellationToken cancellationToken)
    {
        var currentClients = await GetCurrentClients(realm, KeycloakConstants.clientPrefix, cancellationToken);

        var permissions = new List<ClientPermissionModel>();

        var realmRoleComposites = await _keycloakRoleService.GetRealmRoleCompositesByNameAsync(realm, roleName, cancellationToken);

        foreach (var client in currentClients)
        {
            var clientPermissions = await GetClientRoleMappingsAsync(realm, client.id, cancellationToken);

            if (clientPermissions.Count > 0)
            {
                //clientPermissions.ForEach(a => a.selected = realmRoleComposites.Any(b => b.id == a.id) ? true : false);
                var orderedClientPermissions = clientPermissions.ToList().OrderBy(x => x.name);
                permissions.Add(new ClientPermissionModel() { application = client.clientId, Permissions = orderedClientPermissions });
            }
        }

        return permissions;
    }



}
