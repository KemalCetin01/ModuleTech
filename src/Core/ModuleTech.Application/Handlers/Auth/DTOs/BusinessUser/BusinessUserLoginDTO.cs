using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;

public class BusinessUserLoginDTO : IResponse
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}