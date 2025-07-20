using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;

public class ErrorModel
{
    public string error { get; set; } = null!;
    public string error_description { get; set; } = null!;
}
