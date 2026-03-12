using ModuleTech.Application.Core.Infrastructure.Services.Category;
using ModuleTech.Application.DTOs.Category.Response;
using ModuleTech.Application.Handlers.Category.DTOs;
using ModuleTech.Core.Base.Handlers;
using AutoMapper;

namespace ModuleTech.Application.Handlers.Category.Queries;

public class GetCategoryDetailsQuery : IQuery<CategoryDTO>
{
    public Guid Id { get; set; }
}

public sealed class GetCategoryDetailsQueryHandler : BaseQueryHandler<GetCategoryDetailsQuery, CategoryDTO>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public GetCategoryDetailsQueryHandler(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    public override async Task<CategoryDTO> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<CategoryDTO>(result);
    }
}
