using ModuleTech.Core.Networking.Http.Services;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;

public interface IKeycloakTokenService : IRestService
{
    Task GenerateTokenAsync(CancellationToken cancellationToken  );
}

