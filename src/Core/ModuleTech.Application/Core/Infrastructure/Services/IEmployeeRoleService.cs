using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.Base.Models;
using ModuleTech.Application.Handlers.EmployeeRoles.Commands;
using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Infrastructure.Services;
public interface IEmployeeRoleService : IScopedService
{
    Task<PagedResponse<EmployeeRoleDTO>> SearchAsync(SearchQueryModel<SearchUserEmployeeRolesQueryFilterModel> searchQuery, CancellationToken cancellationToken);
    Task<ICollection<EmployeeRoleKeyValueDTO>> SearchFKeyAsync(string search, CancellationToken cancellationToken);
    Task<EmployeeRoleDTO> AddAsync(CreateEmployeeRoleCommand createEmployeeCommand, CancellationToken cancellationToken);
    Task<EmployeeRoleDTO> UpdateAsync(UpdateEmployeeRoleCommand updateEmployeeCommand, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken);
    Task<EmployeeRoleDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken);

}