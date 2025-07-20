﻿using Microsoft.AspNetCore.Mvc;
using ModuleTech.Core.Networking.Http.Services;
using ModuleTech.Infrastructure.Clients.Keycloak.Models;
using System.Net;

namespace ModuleTech.Infrastructure.Clients.Keycloak.Interfaces;
public interface IKeycloakUserService : IRestService
{
    KeycloakUserInfoModel GetUserDetails(string token);
    Task<List<UserResponse>> GetUsersAsync(string realm, CancellationToken cancellationToken);
    Task<KeycloakResponse> CreateUserAsync(string realm, UserRepresentation userRepresentation, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(string realm, string userId, CancellationToken cancellationToken);
    Task<bool> UpdateUserAsync(string realm, UserRepresentation userRepresentation, CancellationToken cancellationToken);
    Task<bool> SoftDeleteUserAsync(string realm, string userId, CancellationToken cancellationToken);
    Task<UserResponse> GetUserById(string realm, string id, CancellationToken cancellationToken);
    Task<bool> UpdateUserPasswordAsync(string realm, string userId, CredentialRepresentation credentialRepresentation, CancellationToken cancellationToken);

}
