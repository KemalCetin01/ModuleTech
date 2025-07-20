using ModuleTech.Application.DTOs.Identity.Request;
using ModuleTech.Application.DTOs.Identity.Response;

namespace ModuleTech.Application.Core.Infrastructure.Services;

public interface IIdentityEmployeeService : IIdentityBaseService
{
    Task<bool> UpdateRolePermissions(UpdateIdentityRolePermissionsRequestDto request, CancellationToken cancellationToken);

    Task<GetRolePermissionsResponseDto> GetRolePermissions(string roleName, CancellationToken cancellationToken);
}