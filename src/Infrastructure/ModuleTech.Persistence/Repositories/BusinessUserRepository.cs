using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Core.Base.Extentions;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Data.Data.Concrete;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Persistence.Context;
using Ozdisan.ECommerce.Services.Identity.Persistence.Repositories;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Identity.Persistence.Repositories;

public class BusinessUserRepository : Repository<BusinessUser, AppDbContext>, IBusinessUserRepository
{
    public BusinessUserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<SearchListModel<BusinessUser>> GetAll(SearchQueryModel<BusinessUserQueryServiceFilter> searchQuery, CancellationToken cancellationToken)
    {
        var query = Queryable();
        query = query.Include(x => x.User);
        query = query.Include(x => x.UserEmployee).ThenInclude(x => x.User);
        //query = query.Include(x => x.User.CreatedByUser);
        query = query.Where(x => x.User.IsDeleted == false);

        if (searchQuery.Filter != null) { query = BusinessUserTableFilter.Filter(query, searchQuery.Filter); }
        return await SearchAsync(query, searchQuery, cancellationToken);
    }

    public async Task<BusinessUser> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await Queryable()
           .Include(x => x.User)
           .Where(x => x.UserId == id && x.User.IsDeleted == false).FirstOrDefaultAsync(cancellationToken);
    }

    protected override IQueryable<BusinessUser> SearchOrderQuery(IQueryable<BusinessUser> query, SortModel? sortModel)
    {
        if (sortModel == null) return query;
        return sortModel.Field switch
        {
            _ when sortModel.Field.Equals(BusinessUserConstants.fullName, StringComparison.InvariantCultureIgnoreCase) => query.OrderByDirection(x => (x.User.FirstName.ToLower() + " " + x.User.LastName.ToLower()), sortModel.Direction.ToLower()),
            _ when sortModel.Field.Equals(nameof(BusinessUser.User.Email), StringComparison.InvariantCultureIgnoreCase) => query.OrderByDirection(x => x.User.Email, sortModel.Direction),
            _ when sortModel.Field.Equals(BusinessUserConstants.representative, StringComparison.InvariantCultureIgnoreCase) => query.OrderByDirection(x => (x.UserEmployee.User.FirstName + " " + x.UserEmployee.User.LastName), sortModel.Direction),
            _ => query
        };
    }

    protected override IQueryable<BusinessUser> GlobalSearchQuery(IQueryable<BusinessUser> query, string? searchQuery)
    {
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            var globalSearch = searchQuery.ToUpper();
            query = query.Where(x => (x.User.FirstName + " " + x.User.LastName).ToUpper().Contains(globalSearch)
                            || (x.UserEmployee.User.FirstName + " " + x.UserEmployee.User.LastName).ToUpper().Contains(globalSearch)
                             || x.User.Email!.ToUpper().Contains(globalSearch));
        }

        return query;
    }

    public async Task<int> GetActiveUserInRoleCountAsync(Guid userGroupRoleId, CancellationToken cancellationToken)
    => await Queryable().Where(x => !x.IsDeleted && x.UserGroupRoleId == userGroupRoleId).CountAsync(cancellationToken);

    public async Task<BusinessUser?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await Queryable().Include(x => x.User).Where(x => x.User.Email == email && !x.IsDeleted).FirstOrDefaultAsync();
    }

    public Task<List<BusinessUser>> GetUsersByBusinessKeycloakId(Guid identityGroupRefId, CancellationToken cancellationToken)
    {
        var businessUserList = Queryable().Include(x => x.User)
           .Where(x => !x.IsDeleted)
           .ToListAsync(cancellationToken);
        return businessUserList;
    }

}
