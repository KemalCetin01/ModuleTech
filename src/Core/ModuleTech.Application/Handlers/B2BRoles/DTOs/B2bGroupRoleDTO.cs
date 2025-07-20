using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.B2bRoles.DTOs;

public class B2bGroupRoleDTO : IResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = null!;
}
