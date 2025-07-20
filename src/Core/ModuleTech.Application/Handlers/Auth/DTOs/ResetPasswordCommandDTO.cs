using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class ResetPasswordCommandDTO : IResponse
{
    public string Email { get; set; }
}
