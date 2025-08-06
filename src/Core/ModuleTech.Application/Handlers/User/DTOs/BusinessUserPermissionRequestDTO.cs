using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class BusinessUserPermissionRequestDTO : IRestResponse
{
    public string id { get; set; }
    public string name { get; set; }
}