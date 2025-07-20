using ModuleTech.Core.Networking.Http.Models;
namespace ModuleTech.Infrastructure.Clients.Keycloak.Models
{
    public class KeycloakRootMappings : IRestResponse
    {
        public Dictionary<string, KeycloakClientMappings> clientMappings { get; set; }
    }
}
