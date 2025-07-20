using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class B2BUserRolePermissionDTO : IResponse
{
    public string roleId { get; set; }
    public string roleName { get; set; }
    public Guid userId { get; set; }
    public IEnumerable<B2BUserPermissionDTO>? Permissions { get; set; }
}
