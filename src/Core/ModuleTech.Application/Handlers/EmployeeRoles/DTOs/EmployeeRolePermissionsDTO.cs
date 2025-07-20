using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
public class EmployeeRolePermissionsDTO : IResponse
{
    public string application { get; set; }
    public string containerId { get; set; }
    public IEnumerable<PermissionDTO>? Permissions { get; set; }
}
