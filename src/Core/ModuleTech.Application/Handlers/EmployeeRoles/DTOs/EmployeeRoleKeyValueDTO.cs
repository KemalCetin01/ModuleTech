using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
public class EmployeeRoleKeyValueDTO : IResponse
{
    public Guid Value { get; init; }
    public string Label { get; set; } = null!;
}