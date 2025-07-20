using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class RefreshTokenDTO : IResponse
{
    public string RefreshToken { get; set; }
}