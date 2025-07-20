using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.DTOs.Identity.Response;
public class CreateIdentityBusinessResponseDto : IResponse
{
    public bool IsSuccess { get; set; }
    public Guid IdentityRefId { get; set; }
}
