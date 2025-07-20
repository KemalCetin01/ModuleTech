namespace ModuleTech.Application.DTOs.Identity.Request;
public class IdentityLoginRequestDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}