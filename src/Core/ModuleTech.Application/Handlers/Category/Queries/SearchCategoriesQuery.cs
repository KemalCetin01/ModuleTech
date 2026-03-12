using ModuleTech.Application.Core.Infrastructure.Services.Category;
using ModuleTech.Application.Handlers.Category.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;
using AutoMapper;

namespace ModuleTech.Application.Handlers.Category.Queries;

public class SearchCategoriesQuery : SearchQuery<SearchCategoryFilter, PagedResponse<CategoryDTO>>
{
}

public sealed class SearchCategoriesQueryHandler : BaseQueryHandler<SearchCategoriesQuery, PagedResponse<CategoryDTO>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryService _categoryService;

    public SearchCategoriesQueryHandler(IMapper mapper, ICategoryService categoryService)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public override async Task<PagedResponse<CategoryDTO>> Handle(SearchCategoriesQuery request, CancellationToken cancellationToken)
    {
        var searchResult = _mapper.Map<SearchQueryModel<SearchCategoryFilterModel>>(request);
        return await _categoryService.SearchAsync(searchResult, cancellationToken);
    }
}
