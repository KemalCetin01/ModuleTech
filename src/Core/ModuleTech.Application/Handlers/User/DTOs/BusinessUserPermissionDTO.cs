using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class BusinessUserPermissionDTO : IRestResponse
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public bool selected { get; set; }
    public bool disabled { get; set; }
}