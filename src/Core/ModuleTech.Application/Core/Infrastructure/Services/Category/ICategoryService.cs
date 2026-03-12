using ModuleTech.Application.DTOs.Category.Response;
using ModuleTech.Application.Handlers.Category.Commands;
using ModuleTech.Application.Handlers.Category.DTOs;
using ModuleTech.Core.Base.Dtos.Response;
using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Infrastructure.Services.Category;

public interface ICategoryService : IScopedService
{
    Task<PagedResponse<CategoryDTO>> SearchAsync(SearchQueryModel<SearchCategoryFilterModel> searchQuery, CancellationToken cancellationToken);
    Task<GetAllCategoriesResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<CategoryDTO> AddAsync(CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken);
    Task<CategoryDTO> UpdateAsync(UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<List<LabelValueResponse>> GetKeyValueAsync(CancellationToken cancellationToken);
}
