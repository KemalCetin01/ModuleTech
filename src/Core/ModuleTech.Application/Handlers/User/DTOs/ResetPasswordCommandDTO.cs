using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class ResetPasswordCommandDTO : IResponse
{
    public Guid UserId { get; set; }
    public string Password { get; set; } = null!;
    public string RePassword { get; set; } = null!;
}