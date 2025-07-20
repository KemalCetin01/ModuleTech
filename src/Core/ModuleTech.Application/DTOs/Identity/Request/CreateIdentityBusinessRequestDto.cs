namespace ModuleTech.Application.DTOs.Identity.Request;
public class CreateIdentityBusinessRequestDto
{
    public CreateIdentityBusinessRequestDto(string businessCode)
    {
        BusinessCode = businessCode;
    }

    public string BusinessCode { get; set; } = null!;

}