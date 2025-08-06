using ModuleTech.Core.Base.Interface;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Persistence.Repositories;

public interface IBusinessUserRepository : IRepository<BusinessUser>
{
    Task<SearchListModel<BusinessUser>> GetAll(SearchQueryModel<BusinessUserQueryServiceFilter> searchQuery, CancellationToken cancellationToken);
    Task<BusinessUser> GetById(Guid id, CancellationToken cancellationToken);
    Task<BusinessUser?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<int> GetActiveUserInRoleCountAsync(Guid userGroupRoleId, CancellationToken cancellationToken);
    Task<List<BusinessUser>> GetUsersByBusinessKeycloakId(Guid identityGroupRefId, CancellationToken cancellationToken);
}
