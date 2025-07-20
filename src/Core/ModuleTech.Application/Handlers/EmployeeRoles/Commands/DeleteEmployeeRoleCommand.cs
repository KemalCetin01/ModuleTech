using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.ExceptionHandling.Exceptions;
using ModuleTech.Application.Core.Infrastructure.Services;
namespace ModuleTech.Application.Handlers.EmployeeRoles.Commands;
public class DeleteEmployeeRoleCommand : ICommand<DataResponse<bool>>
{
    public Guid Id { get; set; }
}
public sealed class DeleteEmployeeRoleCommandHandler : BaseCommandHandler<DeleteEmployeeRoleCommand, DataResponse<bool>>
{
    private readonly IEmployeeRoleService _employeeRoleService;
    private readonly IUserEmployeeService _userEmployeeService;

    public DeleteEmployeeRoleCommandHandler(IEmployeeRoleService employeeRoleService, IUserEmployeeService userEmployeeService)
    {
        _employeeRoleService = employeeRoleService;
        _userEmployeeService = userEmployeeService;
    }


    public override async Task<DataResponse<bool>> Handle(DeleteEmployeeRoleCommand request, CancellationToken cancellationToken)
    {
        var activeUserInRoleCount=await _userEmployeeService.GetActiveUserInRoleCountAsync(request.Id, cancellationToken);
        if (activeUserInRoleCount>0)
        {
            var errorMessage = string.Format(UserStatusCodes.ActiveUserInRole.Message, activeUserInRoleCount);
            throw new ValidationException(errorMessage, UserStatusCodes.ActiveUserInRole.StatusCode);
        }
        var result = await _employeeRoleService.DeleteAsync(request.Id, cancellationToken);
        return new DataResponse<bool> { Data = result };

    }
}