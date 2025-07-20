using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
using ModuleTech.Core.Base.Interface;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Persistence.Repositories;
public interface IEmployeeRoleRepository : IRepository<EmployeeRole>
{
    Task<bool> HasRoleAsync(string? name, Guid? id, CancellationToken cancellationToken  );
    Task<SearchListModel<EmployeeRole>> SearchAsync(SearchQueryModel<SearchUserEmployeeRolesQueryFilterModel> searchQuery, CancellationToken cancellationToken);
    Task<ICollection<EmployeeRoleKeyValueDTO>> SearchFKeyAsync(string search, CancellationToken cancellationToken);
}

