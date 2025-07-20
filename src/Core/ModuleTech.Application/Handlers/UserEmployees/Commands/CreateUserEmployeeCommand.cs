using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.UserEmployees.DTOs;

namespace ModuleTech.Application.Handlers.UserEmployees.Commands;
public class CreateUserEmployeeCommand : CreateUserEmployeeCommandDTO, ICommand<UserEmployeeDTO>
{
  
}

public sealed class CreateEmployeeCommandHandler : BaseCommandHandler<CreateUserEmployeeCommand, UserEmployeeDTO>
{
    private readonly IUserEmployeeService _employeeService;

    public CreateEmployeeCommandHandler(IUserEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    public override async Task<UserEmployeeDTO> Handle(CreateUserEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _employeeService.CreateAsync(request, cancellationToken);


    }
}

