using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.BusinessUserRoles.DTOs;

public class BusinessUserGroupRoleDTO : IResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = null!;
}
