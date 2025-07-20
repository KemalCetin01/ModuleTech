using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.DTOs.Identity.Response;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace ModuleTech.Infrastructure.Services;

public class IdentityKeycloakEmployeeService : IdentityKeycloakBaseService, IIdentityEmployeeService
{
    private readonly KeycloakOptions _keycloakOptions;

    public IdentityKeycloakEmployeeService(IOptions<KeycloakOptions> options,
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

    public async Task<GetRolePermissionsResponseDto> GetRolePermissions(string roleName, CancellationToken cancellationToken)
    {
        List<ClientPermissionModel> permissionModels = await _keycloakClientService.GetPermissionsAsync(Realm, roleName, cancellationToken);
        return _mapper.Map<GetRolePermissionsResponseDto>(permissionModels);
    }

    public async Task<bool> UpdateRolePermissions(UpdateIdentityRolePermissionsRequestDto request, CancellationToken cancellationToken)
    {
        return await _keycloakRoleService.SetRolePermissions(Realm, request.RoleName, request.PermissionIds, cancellationToken);
    }
}