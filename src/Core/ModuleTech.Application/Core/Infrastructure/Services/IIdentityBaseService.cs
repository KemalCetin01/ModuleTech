using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.DTOs.Identity.Response;

namespace ModuleTech.Application.Core.Infrastructure.Services;

public interface IIdentityBaseService
{
    Task<CreateIdentityUserResponseDto> CreateUserAsync(CreateIdentityUserRequestDto request, CancellationToken cancellationToken);

    Task<UpdateIdentityUserResponseDto> UpdateUserAsync(UpdateIdentityUserRequestDto request, CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(Guid identityRefId, CancellationToken cancellationToken);

    Task<bool> UpdateUserPasswordAsync(UpdateIdentityUserPasswordRequestDto request, CancellationToken cancellationToken);

    Task<bool> UpdateUserRolesAsync(UpdateIdentityUserRolesRequestDto request, CancellationToken cancellationToken);

    Task<bool> CreateRoleAsync(CreateIdentityRoleRequestDto request, CancellationToken cancellationToken);

    Task<bool> UpdateRoleAsync(UpdateIdentityRoleRequestDto request, CancellationToken cancellationToken);

    Task<bool> DeleteRoleAsync(string roleName, CancellationToken cancellationToken);
    
}