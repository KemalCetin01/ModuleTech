namespace ModuleTech.Application.DTOs.Identity.Request;

public class UpdateIdentityUserPasswordRequestDto
{
    public Guid IdentityRefId { get; set; }
    public bool Temporary { get; set; } = false;
    public string Password { get; set; } = null!;
}
