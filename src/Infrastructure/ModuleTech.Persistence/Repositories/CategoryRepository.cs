using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Core.Base.Dtos.Response;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using ModuleTech.Core.Data.Data.Concrete;

namespace ModuleTech.Persistence.Repositories;

public class CategoryRepository : Repository<Category, AppDbContext>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> HasCategoryExists(string name, Guid? id, CancellationToken cancellationToken)
    {
        return await Queryable().AnyAsync(x => x.Name == name && x.Id != id && !x.IsDeleted);
    }

    public async Task<List<LabelValueResponse>> GetKeyValueAsync(CancellationToken cancellationToken)
    {
        return await Queryable()
            .Where(x => !x.IsDeleted)
            .Select(x => new LabelValueResponse { Value = x.Id, Label = x.Name })
            .ToListAsync(cancellationToken);
    }

    public async Task<SearchListModel<Category>> SearchAsync(SearchQueryModel<SearchCategoryFilterModel> searchQuery, CancellationToken cancellationToken)
    {
        var result = Queryable().AsNoTracking();

        if (searchQuery.Filter != null)
        {
            if (!string.IsNullOrEmpty(searchQuery.Filter.Name))
            {
                result = result.Where(x => x.Name.Contains(searchQuery.Filter.Name));
            }
        }

        return await SearchAsync(result, searchQuery, cancellationToken);
    }
}
