using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Handlers.EmployeeRoles.DTOs;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Data.Data.Concrete;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Identity.Persistence.Repositories;
public class EmployeeRoleRepository : Repository<EmployeeRole, AppDbContext>, IEmployeeRoleRepository
{
    public EmployeeRoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<bool> HasRoleAsync(string? name, Guid? id, CancellationToken cancellationToken  )
    {
        return await Queryable().AnyAsync(x => x.Name == name && x.Id != id && x.IsDeleted == false, cancellationToken);
    }

    public async Task<SearchListModel<EmployeeRole>> SearchAsync(SearchQueryModel<SearchUserEmployeeRolesQueryFilterModel> searchQuery, CancellationToken cancellationToken)
    {
        var query = Queryable().Where(x => x.IsDeleted == false);

        if (searchQuery.Filter != null)
        {
            if (searchQuery.Filter.Name != null)
                query = query.Where(x => x.Name.ToUpper().Contains(searchQuery.Filter.Name.ToUpper()));
            if (searchQuery.Filter.Description != null)
                query = query.Where(x => x.Description.ToUpper().Contains(searchQuery.Filter.Description.ToUpper()));

            if (searchQuery.Filter.FirstDiscountRate != null)
            {
                query = query.Where(x => x.DiscountRate >= searchQuery.Filter.FirstDiscountRate);
            }
            if (searchQuery.Filter.LastDiscountRate != null && searchQuery.Filter.LastDiscountRate > 0)
            {
                query = query.Where(x => x.DiscountRate <= searchQuery.Filter.LastDiscountRate);
            }
        }


        return await SearchAsync(query, searchQuery, cancellationToken);
    }
    protected override IQueryable<EmployeeRole> SearchOrderQuery(IQueryable<EmployeeRole> query, SortModel? sortModel)
    {
        if (sortModel == null)
        {
            return query;
        }
        if (sortModel.Direction.ToUpper() == "DESC")
        {
            switch (sortModel.Field)
            {
                case EmployeeRoleConstants.Name:
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case EmployeeRoleConstants.Description:
                    query = query.OrderByDescending(x => x.Description);
                    break;
                case EmployeeRoleConstants.DiscountRate:
                    query = query.OrderByDescending(x => x.DiscountRate);
                    break;
            }
        }
        else
        {
            switch (sortModel.Field)
            {
                case EmployeeRoleConstants.Name:
                    query = query.OrderBy(x => x.Name);
                    break;
                case EmployeeRoleConstants.Description:
                    query = query.OrderBy(x => x.Description);
                    break;
                case EmployeeRoleConstants.DiscountRate:
                    query = query.OrderBy(x => x.DiscountRate);
                    break;
            }
        }
        return query;
    }
    public async Task<ICollection<EmployeeRoleKeyValueDTO>> SearchFKeyAsync(string search, CancellationToken cancellationToken)
    {
        var q = Queryable().Where(x => !x.IsDeleted);
        var searchQueryModel = new SearchQueryModel<CurrentAccountValueLabelQueryServiceFilter>();
        if (!string.IsNullOrWhiteSpace(search)) { searchQueryModel.GlobalSearch = search; }
        var result = await SearchAsync(q, searchQueryModel);

        return result.Data.Select(x => new EmployeeRoleKeyValueDTO()
        {
            Label = x.Description,
            Value = x.Id
        }).ToList();
    }
}
