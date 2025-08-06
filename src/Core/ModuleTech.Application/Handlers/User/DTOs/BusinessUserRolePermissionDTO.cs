using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class BusinessUserRolePermissionDTO : IResponse
{
    public string roleId { get; set; }
    public string roleName { get; set; }
    public Guid userId { get; set; }
    public IEnumerable<BusinessUserPermissionDTO>? Permissions { get; set; }
}
