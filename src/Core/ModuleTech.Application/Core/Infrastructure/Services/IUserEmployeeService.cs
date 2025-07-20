using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Core.Base.Models;
using ModuleTech.Application.Handlers.UserEmployees.Commands;
using ModuleTech.Application.Handlers.UserEmployees.DTOs;
using ModuleTech.Application.Models.FKeyModel;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Infrastructure.Services;

public interface IUserEmployeeService : IScopedService
{
    Task<ICollection<LabelValueModel>> GetEmployees(string search, CancellationToken cancellationToken  );
    Task<PagedResponse<UserEmployeeDTO>> SearchAsync(SearchQueryModel<SearchUserEmployeesQueryFilterModel> searchQuery, CancellationToken cancellationToken  );
    Task<UserEmployeeDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken  );
    Task<UserEmployeeDTO> CreateAsync(CreateUserEmployeeCommandDTO createEmployeeCommand, CancellationToken cancellationToken  );
    Task<UserEmployeeDTO> UpdateAsync(UpdateUserEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken  );
    Task DeleteAsync(Guid Id, CancellationToken cancellationToken  );
    Task<int> GetActiveUserInRoleCountAsync(Guid roleId, CancellationToken cancellationToken  );
}
