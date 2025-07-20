using System.Text.Json.Serialization;
using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.DTOs.Identity;
public class IdentityUserInfoResponseDto : IResponse
{

    public string? Name { get; set; }
    public string? Email { get; set; }
    public Dictionary<string, IdentityResourceRoleDto>? ResourceAccess { get; set; }
    public Dictionary<string, IdentityRealmRoleDto>? RealmAccess { get; set; }
}

public class IdentityResourceRoleDto
{
    [JsonPropertyName("roles")]
    public List<string>? Roles { get; set; }
}
public class IdentityRealmRoleDto
{
    [JsonPropertyName("roles")]
    public List<string>? Roles { get; set; }
}