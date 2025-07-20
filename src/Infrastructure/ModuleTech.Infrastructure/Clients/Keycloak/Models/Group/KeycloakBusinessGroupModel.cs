using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;

public class KeycloakBusinessGroupModel : IRestResponse
{
    public string id { get; set; }
    public string name { get; set; }
    public string path { get; set; }
}
