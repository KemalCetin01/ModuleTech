namespace ModuleTech.Application.Handlers.B2bRoles.DTOs;

public class SetGroupPermissionsCommandDTO
{
    public Guid id { get; set; }
    public IReadOnlyCollection<KeycloakGroupPermissionDTO> Permissions { get; set; }
}
