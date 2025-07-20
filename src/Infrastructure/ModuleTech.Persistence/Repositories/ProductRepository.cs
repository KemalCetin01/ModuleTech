using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;
using ModuleTech.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using ModuleTech.Core.Data.Data.Concrete;

namespace ModuleTech.Persistence.Repositories;

public class ProductRepository : Repository<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> HasProductExits(string name, Guid? id, CancellationToken cancellationToken)
    {
        return await Queryable().AnyAsync(x=>x.Name==name && x.Id!=id&&!x.IsDeleted);
    }

    public async Task<SearchListModel<Product>> SearchAsync(SearchQueryModel<SearchProductFilterModel> searchQuery, CancellationToken cancellationToken)
    {
        var result = Queryable().AsNoTracking();
        if (searchQuery.Filter!=null)
        {
            if (!string.IsNullOrEmpty(searchQuery.Filter.Name))
            {
                result = result.Where(p => p.Name.Contains(searchQuery.Filter.Name));
            }
        }
        return await SearchAsync(result,searchQuery, cancellationToken);
    }
}
