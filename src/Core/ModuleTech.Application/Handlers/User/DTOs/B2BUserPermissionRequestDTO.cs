using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class B2BUserPermissionRequestDTO : IRestResponse
{
    public string id { get; set; }
    public string name { get; set; }
}