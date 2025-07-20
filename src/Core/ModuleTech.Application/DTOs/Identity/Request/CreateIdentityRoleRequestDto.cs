namespace ModuleTech.Application.DTOs.Identity.Request;
public class CreateIdentityRoleRequestDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}