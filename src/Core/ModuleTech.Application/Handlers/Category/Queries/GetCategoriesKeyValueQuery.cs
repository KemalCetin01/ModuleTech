using ModuleTech.Application.Core.Infrastructure.Services.Category;
using ModuleTech.Core.Base.Dtos.Response;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;

namespace ModuleTech.Application.Handlers.Category.Queries;

public class GetCategoriesKeyValueQuery : IQuery<ListResponse<LabelValueResponse>> { }

public sealed class GetCategoriesKeyValueQueryHandler : BaseQueryHandler<GetCategoriesKeyValueQuery, ListResponse<LabelValueResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesKeyValueQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override async Task<ListResponse<LabelValueResponse>> Handle(GetCategoriesKeyValueQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetKeyValueAsync(cancellationToken);
        return new ListResponse<LabelValueResponse>(result);
    }
}
