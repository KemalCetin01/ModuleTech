namespace ModuleTech.Application.DTOs.Identity.Request;

public class UpdateIdentityUserRolesRequestDto
{
    public Guid IdentityRefId { get; set; }
    public List<string>? CurrentRoles { get; set; }
    public List<string>? DeletedRoles { get; set; }
    
}
