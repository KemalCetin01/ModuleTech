using ModuleTech.Core.Base.Interface;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Persistence.Repositories;

public interface IProductRepository: IRepository<Product>
{
    Task<SearchListModel<Product>> SearchAsync(SearchQueryModel<SearchProductFilterModel> searchQuery, CancellationToken cancellationToken);
    Task<bool> HasProductExits(string name, Guid? id, CancellationToken cancellationToken);
}
