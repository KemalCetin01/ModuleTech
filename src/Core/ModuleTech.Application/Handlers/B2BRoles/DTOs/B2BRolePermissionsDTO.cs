using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.B2bRoles.DTOs;

public class B2BRolePermissionsDTO : IResponse
{
    public string application { get; set; }
    public string clientId { get; set; }

    public IEnumerable<PermissionDTO>? Permissions { get; set; }
}
