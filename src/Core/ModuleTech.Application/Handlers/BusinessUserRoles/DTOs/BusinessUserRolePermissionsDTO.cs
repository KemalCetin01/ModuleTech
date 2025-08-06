using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.BusinessUserRoles.DTOs;

public class BusinessUserRolePermissionsDTO : IResponse
{
    public string application { get; set; }
    public string clientId { get; set; }

    public IEnumerable<PermissionDTO>? Permissions { get; set; }
}
