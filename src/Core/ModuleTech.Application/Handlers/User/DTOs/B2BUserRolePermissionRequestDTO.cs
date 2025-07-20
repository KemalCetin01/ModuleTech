using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class B2BUserRolePermissionRequestDTO : IResponse
{
    public string? roleId { get; set; }
    public string? roleName { get; set; }
    public Guid userId { get; set; }
    public IEnumerable<B2BUserPermissionRequestDTO>? Permissions { get; set; }
}
