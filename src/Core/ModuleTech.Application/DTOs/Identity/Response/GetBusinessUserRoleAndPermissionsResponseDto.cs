using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.DTOs.Identity.Response;

public class GetBusinessUserRoleAndPermissionsResponseDto : IResponse
{
    public string RoleId { get; set; } = null!;
    public string RoleName { get; set; } = null!;
    public List<GetBusinessUserPermissionDto>? Permissions { get; set; }
}

public class GetBusinessUserPermissionDto {
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Selected { get; set; }
    public bool Disabled { get; set; }
}
