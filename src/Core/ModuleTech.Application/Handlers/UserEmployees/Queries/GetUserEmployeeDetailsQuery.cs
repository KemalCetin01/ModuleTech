using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.UserEmployees.DTOs;

namespace ModuleTech.Application.Handlers.UserEmployees.Queries;

public class GetUserEmployeeDetailsQuery : IQuery<UserEmployeeDTO>
{
    public Guid userId { get; set; }
}
public sealed class GetEmployeeDetailsQueryHandler : BaseQueryHandler<GetUserEmployeeDetailsQuery, UserEmployeeDTO>
{
    protected readonly IUserEmployeeService _employeeService;

    public GetEmployeeDetailsQueryHandler(IUserEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public override async Task<UserEmployeeDTO> Handle(GetUserEmployeeDetailsQuery request, CancellationToken cancellationToken  )
    {
        return await _employeeService.GetByIdAsync(request.userId, cancellationToken);

    }
}