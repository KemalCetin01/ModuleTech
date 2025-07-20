using ModuleTech.Core.Base.Dtos;
using System.Text.Json.Serialization;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Models
{
    public class KeycloakUserInfoModel : IResponse
    {

        public string? Name { get; set; }
        public string? Email { get; set; }
        public Dictionary<string, ResourceRole>? ResourceAccess { get; set; }
        public Dictionary<string, IdentityRealmRoleInfoDto>? RealmAccess { get; set; }
    }

    public class ResourceRole
    {
        public List<string> roles { get; set; }
    }
    public class IdentityRealmRoleInfoDto
    {
        [JsonPropertyName("roles")]
        public List<string>? Roles { get; set; }
    }

}
