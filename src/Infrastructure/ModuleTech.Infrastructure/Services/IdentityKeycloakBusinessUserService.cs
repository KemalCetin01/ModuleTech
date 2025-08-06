using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Models.Token;
using ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;
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

    
    
    public async Task<AuthenticationDTO> LoginAsync(BusinessUserLoginDTO request, CancellationToken cancellationToken)
    {
        KeycloakLoginModel keycloakLoginModel = new KeycloakLoginModel
        {
            Email = request.Email,
            Password = request.Password,
            ClientId = _keycloakOptions.moduleTech_client_id,
            ClientSecret = _keycloakOptions.moduleTech_client_secret,
            GrantType = _keycloakOptions.ecommerce_grant_type,
            Scope = _keycloakOptions.ecommerce_scope,
            Realm = Realm
        };
        TokenModel token = await _keycloakAccountService.LoginAsync(keycloakLoginModel, cancellationToken);
        return _mapper.Map<AuthenticationDTO>(token);
    }

    public async Task<AuthenticationDTO> RefreshTokenLoginAsync(string refreshToken, CancellationToken cancellationToken)
    {
        RefreshTokenLoginModel refreshLoginModel = new RefreshTokenLoginModel
        {
            Realm = Realm,
            ClientId = _keycloakOptions.moduleTech_client_id,
            ClientSecret = _keycloakOptions.moduleTech_client_secret,
            GrantType = _keycloakOptions.refresh_token_grant_type,
            RefreshToken = refreshToken
        };
        TokenModel token = await _keycloakAccountService.RefreshTokenLoginAsync(refreshLoginModel, cancellationToken);
        return _mapper.Map<AuthenticationDTO>(token);
    }

   
}