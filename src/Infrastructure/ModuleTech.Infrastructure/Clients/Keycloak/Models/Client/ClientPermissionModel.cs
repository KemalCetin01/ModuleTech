using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;

public class ClientPermissionModel : IRestResponse
{
    public string application { get; set; }
    public string containerId { get; set; }
    public IEnumerable<RoleRepresentation>? Permissions { get; set; }

}
