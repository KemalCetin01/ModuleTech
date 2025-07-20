using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Core.Base.Extentions;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Data.Data.Concrete;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Persistence.Context;
using Ozdisan.ECommerce.Services.Identity.Persistence.Repositories;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Identity.Persistence.Repositories;

public class UserB2BRepository : Repository<UserB2B, AppDbContext>, IUserB2BRepository
{
    public UserB2BRepository(AppDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<SearchListModel<UserB2B>> GetAll(SearchQueryModel<UserB2BQueryServiceFilter> searchQuery, CancellationToken cancellationToken)
    {
        var query = Queryable();
        query = query.Include(x => x.User);
        query = query.Include(x => x.UserEmployee).ThenInclude(x => x.User);
        //query = query.Include(x => x.User.CreatedByUser);
        query = query.Where(x => x.User.IsDeleted == false);

        if (searchQuery.Filter != null) { query = UserB2BTableFilter.Filter(query, searchQuery.Filter); }
        return await SearchAsync(query, searchQuery, cancellationToken);
    }

    public async Task<UserB2B> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await Queryable()
           .Include(x => x.User)
           .Where(x => x.UserId == id && x.User.IsDeleted == false).FirstOrDefaultAsync(cancellationToken);
    }

    protected override IQueryable<UserB2B> SearchOrderQuery(IQueryable<UserB2B> query, SortModel? sortModel)
    {
        if (sortModel == null) return query;
        return sortModel.Field switch
        {
            _ when sortModel.Field.Equals(B2BUserConstants.fullName, StringComparison.InvariantCultureIgnoreCase) => query.OrderByDirection(x => (x.User.FirstName.ToLower() + " " + x.User.LastName.ToLower()), sortModel.Direction.ToLower()),
            _ when sortModel.Field.Equals(nameof(UserB2B.User.Email), StringComparison.InvariantCultureIgnoreCase) => query.OrderByDirection(x => x.User.Email, sortModel.Direction),
            _ when sortModel.Field.Equals(B2BUserConstants.representative, StringComparison.InvariantCultureIgnoreCase) => query.OrderByDirection(x => (x.UserEmployee.User.FirstName + " " + x.UserEmployee.User.LastName), sortModel.Direction),
            _ => query
        };
    }

    protected override IQueryable<UserB2B> GlobalSearchQuery(IQueryable<UserB2B> query, string? searchQuery)
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

    public async Task<UserB2B?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await Queryable().Include(x => x.User).Where(x => x.User.Email == email && !x.IsDeleted).FirstOrDefaultAsync();
    }

    public Task<List<UserB2B>> GetUsersByBusinessKeycloakId(Guid identityGroupRefId, CancellationToken cancellationToken)
    {
        var userB2BList = Queryable().Include(x => x.User)
           .Where(x => !x.IsDeleted)
           .ToListAsync(cancellationToken);
        return userB2BList;
    }

}
