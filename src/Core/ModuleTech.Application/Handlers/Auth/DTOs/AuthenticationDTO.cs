using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class AuthenticationDTO : IResponse 
{
    public string AccessToken { get; set; } 
    public int ExpiresIn { get; set; }
    public int RefreshExpiresIn { get; set; }
    public string RefreshToken { get; set; }
    public string TokenType { get; set; }
    public string notbeforepolicy { get; set; }
    public string scope { get; set; }
}
