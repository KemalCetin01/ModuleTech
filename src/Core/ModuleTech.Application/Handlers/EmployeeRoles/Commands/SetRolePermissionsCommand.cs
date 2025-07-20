using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Helpers.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using Microsoft.Extensions.Options;

namespace ModuleTech.Application.Handlers.EmployeeRoles.Commands;
public class SetRolePermissionsCommand : ICommand<DataResponse<bool>>
{
    public Guid id { get; set; }
    public List<string> PermissionIds { get; set; }

}
public sealed class SetPermissionsCommandHandler : BaseCommandHandler<SetRolePermissionsCommand, DataResponse<bool>>
{
    private readonly IEmployeeRoleService _employeeRoleService;

    public SetPermissionsCommandHandler(IEmployeeRoleService employeeRoleService,
        IOptions<KeycloakOptions> options)
    {
        _employeeRoleService = employeeRoleService;
    }


    public override async Task<DataResponse<bool>> Handle(SetRolePermissionsCommand request, CancellationToken cancellationToken)
    {
        var employeeRoleDetail = await _employeeRoleService.GetByIdAsync(request.id, cancellationToken);
        // if (employeeRoleDetail == null)
        //throw new ApiException(EmployeeRoleConstants.EmployeeRoleNotFound);

        //UpdateIdentityRolePermissionsRequestDto updateRoleRequest = new UpdateIdentityRolePermissionsRequestDto
        //{
        //    RoleName = employeeRoleDetail.Name!,
        //    PermissionIds = request.PermissionIds
        //};
        //var result = await _identityEmployeeService.UpdateRolePermissions(updateRoleRequest, cancellationToken);
        //return new DataResponse<bool> { Data = result };

        return new DataResponse<bool>
        {
            Data = true
        };
    }
}


