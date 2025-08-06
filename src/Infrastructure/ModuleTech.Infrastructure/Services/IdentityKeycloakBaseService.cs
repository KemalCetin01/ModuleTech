using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.DTOs.Identity.Response;
using ModuleTech.Core.Base.Extentions;
using ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;
using AutoMapper;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Infrastructure.Services;

public abstract class IdentityKeycloakBaseService : IIdentityBaseService
{
    protected readonly IKeycloakUserService _keycloakUserService;
    protected readonly IKeycloakTokenService _keycloakTokenService;
    protected readonly IKeycloakRoleService _keycloakRoleService;
    protected readonly IKeycloakClientService _keycloakClientService;
    protected readonly IKeycloakRoleMappingService _keycloakRoleMappingService;
    protected readonly IKeycloakAccountService _keycloakAccountService;
    protected readonly IMapper _mapper;
    protected abstract string Realm { get; }

    public IdentityKeycloakBaseService(IKeycloakUserService keycloakUserService, IKeycloakTokenService keycloakTokenService, IKeycloakRoleService keycloakRoleService, IKeycloakClientService keycloakClientService, IKeycloakRoleMappingService keycloakRoleMappingService, IKeycloakAccountService keycloakAccountService, IMapper mapper)
    {
        _keycloakUserService = keycloakUserService;
        _keycloakTokenService = keycloakTokenService;
        _keycloakRoleService = keycloakRoleService;
        _keycloakClientService = keycloakClientService;
        _keycloakRoleMappingService = keycloakRoleMappingService;
        _keycloakAccountService = keycloakAccountService;
        _mapper = mapper;
    }

    public async Task<CreateIdentityUserResponseDto> CreateUserAsync(CreateIdentityUserRequestDto request, CancellationToken cancellationToken)
    {

        UserRepresentation userRepresentation = new UserRepresentation
        {
            createdTimestamp = new DateTimeOffset(request.CreatedDate).ToUnixTimeSeconds(),
            username = request.UserName ?? request.Email,            
            email = request.Email,
            firstName = request.FirstName,
            lastName = request.LastName,
            enabled = true,
            credentials = new[] { new CredentialRepresentation { value = request.Password, type="password",temporary=false} },
            attributes = new Dictionary<string, ICollection<string>>
            {
                { KeycloakConstants.IdentityRefId, new List<string>() { request.UserId.ToString() } }
            }
        };

        KeycloakResponse resp = await _keycloakUserService.CreateUserAsync(Realm, userRepresentation, cancellationToken);

        return new CreateIdentityUserResponseDto(){
            IdentityRefId = new Guid(resp.Id),
            IsSuccess = resp.IsSuccess
        };
    }

    public async Task<UpdateIdentityUserResponseDto> UpdateUserAsync(UpdateIdentityUserRequestDto request, CancellationToken cancellationToken)
    {
        UserRepresentation userRepresentation = new UserRepresentation
        {
            email = request.Email,
            firstName = request.FirstName,
            lastName = request.LastName
        };

        bool isSuccess = await _keycloakUserService.UpdateUserAsync(Realm, userRepresentation, cancellationToken);

        return new UpdateIdentityUserResponseDto(){
            IsSuccess = isSuccess
        };
    }

    public async Task<bool> DeleteUserAsync(Guid identityRefId, CancellationToken cancellationToken)
    {
        return await _keycloakUserService.DeleteUserAsync(Realm, identityRefId.ToString(), cancellationToken);
    }

    public async Task<bool> UpdateUserPasswordAsync(UpdateIdentityUserPasswordRequestDto request, CancellationToken cancellationToken) 
    {
        CredentialRepresentation credentialRepresentation = new CredentialRepresentation
        {
            type = "password",
            value = request.Password,
            temporary = request.Temporary
        };

        return await _keycloakUserService.UpdateUserPasswordAsync(Realm, request.IdentityRefId.ToString(), credentialRepresentation, cancellationToken);
    }

    public async Task<bool> UpdateUserRolesAsync(UpdateIdentityUserRolesRequestDto request, CancellationToken cancellationToken)
    {
        if (!request.DeletedRoles.IsNullOrEmpty()) 
        {
            List<RoleRepresentation> deletedRoles = new List<RoleRepresentation>();
            request.DeletedRoles!.ForEach(roleName => deletedRoles.Add(new RoleRepresentation { name = roleName }));
            await _keycloakRoleMappingService.DeleteRealmRoleMappingForUserAsync(Realm, request.IdentityRefId.ToString(), deletedRoles, cancellationToken);
        }
        if (!request.CurrentRoles.IsNullOrEmpty()) {
            List<RoleRepresentation> currentRoles = new List<RoleRepresentation>();
            request.CurrentRoles!.ForEach(roleName => currentRoles.Add(new RoleRepresentation { name = roleName }));
            await _keycloakRoleMappingService.CreateRealmRoleMappingForUserAsync(Realm, request.IdentityRefId.ToString(), currentRoles, cancellationToken);
        }
        return true;
    }

    public async Task<bool> CreateRoleAsync(CreateIdentityRoleRequestDto request, CancellationToken cancellationToken)
    {
        RoleRepresentation roleRepresentation = new RoleRepresentation
        {
            name = request.Name,
            description = request.Description
        };

        return await _keycloakRoleService.CreateRoleAsync(Realm, roleRepresentation, cancellationToken);

    }

    public async Task<bool> UpdateRoleAsync(UpdateIdentityRoleRequestDto request, CancellationToken cancellationToken)
    {
        RoleRepresentation roleRepresentation = new RoleRepresentation
        {
            name = request.Name,
            description = request.Description
        };

        return await _keycloakRoleService.UpdateRoleAsync(Realm, roleRepresentation, cancellationToken);

    }

    public async Task<bool> DeleteRoleAsync(string roleName, CancellationToken cancellationToken)
    {
       return await _keycloakRoleService.DeleteRoleAsync(Realm, roleName, cancellationToken);
    }

}