namespace ModuleTech.Application.DTOs.Identity.Request;

public class CreateIdentityUserRequestDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}