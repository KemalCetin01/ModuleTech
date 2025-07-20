using ModuleTech.Core.Networking.Http.Models;


namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;

public class KeycloakResponse : IRestResponse
{
    public bool IsSuccess { get; set; }
    public string Id { get; set; } = null!;
}
