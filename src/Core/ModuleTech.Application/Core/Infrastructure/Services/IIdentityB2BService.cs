using ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.DTOs.Identity.Response;

namespace ModuleTech.Application.Core.Infrastructure.Services;

public interface IIdentityB2BService : IIdentityBaseService
{
    Task<AuthenticationDTO> LoginAsync(B2BLoginDTO request, CancellationToken cancellationToken);
    Task<AuthenticationDTO> RefreshTokenLoginAsync(string refreshToken, CancellationToken cancellationToken);

}