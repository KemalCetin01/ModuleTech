using ModuleTech.Core.Base.Dtos.Response;
using ModuleTech.Core.Base.Interface;
using ModuleTech.Core.Base.Models;
using ModuleTech.Domain;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Persistence.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<SearchListModel<Category>> SearchAsync(SearchQueryModel<SearchCategoryFilterModel> searchQuery, CancellationToken cancellationToken);
    Task<bool> HasCategoryExists(string name, Guid? id, CancellationToken cancellationToken);
    Task<List<LabelValueResponse>> GetKeyValueAsync(CancellationToken cancellationToken);
}
