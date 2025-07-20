using ModuleTech.Core.Networking.Http.Models;


namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;

public class ClientModel : IRestResponse
{
    public string id { get; set; }
    public string clientId { get; set; }
    public string name { get; set; }
}
