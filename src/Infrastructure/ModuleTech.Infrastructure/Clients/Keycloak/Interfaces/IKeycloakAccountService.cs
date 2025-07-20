using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Models.Token;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;

public interface IKeycloakAccountService : IScopedService
{
    Task<TokenModel> LoginAsync(KeycloakLoginModel keycloakLoginModel, CancellationToken cancellationToken);
    Task<TokenModel> RefreshTokenLoginAsync(RefreshTokenLoginModel refreshTokenLoginModel, CancellationToken cancellationToken);
}
