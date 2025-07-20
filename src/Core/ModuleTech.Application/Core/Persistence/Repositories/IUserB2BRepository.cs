using ModuleTech.Core.Base.Interface;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Persistence.Repositories;

public interface IUserB2BRepository : IRepository<UserB2B>
{
    Task<SearchListModel<UserB2B>> GetAll(SearchQueryModel<UserB2BQueryServiceFilter> searchQuery, CancellationToken cancellationToken);
    Task<UserB2B> GetById(Guid id, CancellationToken cancellationToken);
    Task<UserB2B?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<int> GetActiveUserInRoleCountAsync(Guid userGroupRoleId, CancellationToken cancellationToken);
    Task<List<UserB2B>> GetUsersByBusinessKeycloakId(Guid identityGroupRefId, CancellationToken cancellationToken);
}
