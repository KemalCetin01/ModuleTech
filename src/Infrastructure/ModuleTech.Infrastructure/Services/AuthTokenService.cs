
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.DTOs.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace ModuleTech.Infrastructure.Services;

public class AuthTokenService : IAuthTokenService
{
    public AuthTokenService()
    {
    }

    public IdentityUserInfoResponseDto GetUserDetailsFromJwtToken(string token, CancellationToken cancellationToken)
    {
        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jsonToken = handler.ReadJwtToken(token);
        var data = jsonToken.Payload;
        var resourceAccess = data.Claims.FirstOrDefault(x => x.Type == "resource_access") != null ? data.Claims.FirstOrDefault(x => x.Type == "resource_access").Value : null;
        var realmAccess = data.Claims.FirstOrDefault(x => x.Type == "realm_access") != null ? data.Claims.FirstOrDefault(x => x.Type == "realm_access").Value : null;
        var name = data.Claims.FirstOrDefault(x => x.Type == "name") != null ? data.Claims.FirstOrDefault(x => x.Type == "name").Value : null;
        var email = data.Claims.FirstOrDefault(x => x.Type == "email") != null ? data.Claims.FirstOrDefault(x => x.Type == "email").Value : null;
        var resourceAccessData = new Dictionary<string, IdentityResourceRoleDto>();
        IdentityRealmRoleDto? realmAccessDto = null;
        if (resourceAccess != null) {
            resourceAccessData = JsonSerializer.Deserialize<Dictionary<string, IdentityResourceRoleDto>>(resourceAccess);
        }
        if (realmAccess != null) {
            realmAccessDto = JsonSerializer.Deserialize<IdentityRealmRoleDto>(realmAccess);

        }
        return new IdentityUserInfoResponseDto
        {
            Name = name,
            Email = email,
            ResourceAccess = resourceAccessData,
            RealmAccess = new Dictionary<string, IdentityRealmRoleDto>
        {
            { "realm_access", realmAccessDto! }
        }
        };
    }
}
