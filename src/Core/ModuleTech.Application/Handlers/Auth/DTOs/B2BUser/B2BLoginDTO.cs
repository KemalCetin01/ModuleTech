using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;

public class B2BLoginDTO : IResponse
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}