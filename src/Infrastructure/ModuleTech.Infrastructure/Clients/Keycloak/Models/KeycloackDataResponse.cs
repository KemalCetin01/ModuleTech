using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;

public class KeycloackDataResponse<T> : IRestResponse
{
    public T? Data { get; set; }

}
