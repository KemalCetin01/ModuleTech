﻿using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;

namespace ModuleTech.Application.Handlers.EmployeeRoles.Commands;
public class UpdateEmployeeRoleCommand : ICommand<EmployeeRoleDTO>
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public int DiscountRate { get; set; }
}
public sealed class UpdateEmployeeRoleCommandHandler : BaseCommandHandler<UpdateEmployeeRoleCommand, EmployeeRoleDTO>
{
    private readonly IEmployeeRoleService _employeeRoleService;

    public UpdateEmployeeRoleCommandHandler(IEmployeeRoleService employeeRoleService)
    {
        _employeeRoleService = employeeRoleService;
    }


    public override async Task<EmployeeRoleDTO> Handle(UpdateEmployeeRoleCommand request, CancellationToken cancellationToken)
    {
        return await _employeeRoleService.UpdateAsync(request, cancellationToken);
    }
}


