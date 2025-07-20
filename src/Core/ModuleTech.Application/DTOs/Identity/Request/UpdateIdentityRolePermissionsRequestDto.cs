namespace ModuleTech.Application.DTOs.Identity.Request;
public class UpdateIdentityRolePermissionsRequestDto
{
    public string RoleName { get; set; } = null!;
    public List<string> PermissionIds { get; set; } = null!;
}