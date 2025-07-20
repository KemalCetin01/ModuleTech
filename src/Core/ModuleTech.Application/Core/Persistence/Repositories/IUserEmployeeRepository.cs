using ModuleTech.Application.Models.FKeyModel;
using ModuleTech.Core.Base.Interface;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Persistence.Repositories;

public interface IUserEmployeeRepository : IRepository<UserEmployee>
{
    Task<ICollection<LabelValueModel>> GetEmployees(string search, CancellationToken cancellationToken  );
    Task<UserEmployee> GetByIdAsync(Guid Id, CancellationToken cancellationToken  );
    Task<SearchListModel<UserEmployee>> SearchAsync(SearchQueryModel<SearchUserEmployeesQueryFilterModel> searchQuery, CancellationToken cancellationToken);
    Task<int> GetActiveUserInRoleCountAsync(Guid roleId, CancellationToken cancellationToken  );
}
