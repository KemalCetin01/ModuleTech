using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace ModuleTech.Infrastructure.Services;

public class IdentityKeycloakBusinessUserService : IdentityKeycloakBaseService, IIdentityBusinessUserService
{
    private readonly KeycloakOptions _keycloakOptions;

    public IdentityKeycloakBusinessUserService(IOptions<KeycloakOptions> options,
        IKeycloakUserService keycloakUserService,
        IKeycloakTokenService keycloakTokenService,
        IKeycloakRoleService keycloakRoleService,
        IKeycloakClientService keycloakClientService,
        IKeycloakRoleMappingService keycloakRoleMappingService,
        IKeycloakAccountService keycloakAccountService,
        IMapper mapper) : base(keycloakUserService, keycloakTokenService, keycloakRoleService, keycloakClientService, keycloakRoleMappingService, keycloakAccountService, mapper)
    {
        _keycloakOptions = options.Value;
    }

    protected override string Realm { get => _keycloakOptions.moduleTech_realm; }
}