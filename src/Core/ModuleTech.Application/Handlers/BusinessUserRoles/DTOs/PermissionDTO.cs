using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Application.Handlers.BusinessUserRoles.DTOs;
public class PermissionDTO : IRestResponse
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public bool selected { get; set; }
}