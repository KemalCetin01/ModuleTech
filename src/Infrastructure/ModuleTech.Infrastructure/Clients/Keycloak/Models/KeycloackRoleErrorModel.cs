using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;

public class KeycloackRoleErrorModel : IRestErrorResponse
{
    public string? Error { get; set; }
}