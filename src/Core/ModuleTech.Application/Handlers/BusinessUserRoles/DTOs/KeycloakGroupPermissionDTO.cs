using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.BusinessUserRoles.DTOs;

public class KeycloakGroupPermissionDTO : IResponse
{
    public string id { get; set; }
    public string name { get; set; }
    public string clientId { get; set; }
}
