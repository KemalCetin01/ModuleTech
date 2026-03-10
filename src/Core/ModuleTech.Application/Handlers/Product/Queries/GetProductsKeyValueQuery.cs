using ModuleTech.Application.Core.Infrastructure.Services.Product;
using ModuleTech.Core.Base.Dtos.Response;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;

namespace ModuleTech.Application.Handlers.Product.Queries;

public class GetProductsKeyValueQuery : IQuery<ListResponse<LabelValueResponse>> { }

public sealed class GetProductsKeyValueQueryHandler : BaseQueryHandler<GetProductsKeyValueQuery, ListResponse<LabelValueResponse>>
{
    private readonly IProductService _productService;

    public GetProductsKeyValueQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<ListResponse<LabelValueResponse>> Handle(GetProductsKeyValueQuery request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetKeyValueAsync(cancellationToken);
        return new ListResponse<LabelValueResponse>(result);
    }
}
