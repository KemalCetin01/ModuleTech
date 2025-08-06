using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class BusinessUserRolePermissionRequestDTO : IResponse
{
    public string? roleId { get; set; }
    public string? roleName { get; set; }
    public Guid userId { get; set; }
    public IEnumerable<BusinessUserPermissionRequestDTO>? Permissions { get; set; }
}
