namespace ModuleTech.Application.Handlers.BusinessUserRoles.DTOs;

public class SetGroupPermissionsCommandDTO
{
    public Guid id { get; set; }
    public IReadOnlyCollection<KeycloakGroupPermissionDTO> Permissions { get; set; }
}
