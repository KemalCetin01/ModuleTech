using Newtonsoft.Json;
using ModuleTech.Core.Networking.Http.Models;
using ModuleTech.Infrastructure.Clients.Keycloak.Models.Base;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Models;
public class UserRepresentation
{
    public string? id { get; set; }
    public string username { get; set; } = null!;
    public long? createdTimestamp { get; set; }
    public bool? enabled { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? email { get; set; }
    public Dictionary<string, ICollection<string>>? attributes { get; set; }
    public ICollection<CredentialRepresentation>? credentials { get; set; }
}