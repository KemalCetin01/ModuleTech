using ModuleTech.Application.Core.Infrastructure.Services.Product;
using ModuleTech.Application.DTOs.Product.Response;
using ModuleTech.Application.Handlers.Product.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;
using AutoMapper;

namespace ModuleTech.Application.Handlers.Product.Queries
{
    public class SearchProductsQuery : SearchQuery<SearchProcutFilter, PagedResponse<ProductDTO>>
    {
    }
    public sealed class GetAllProductsQueryHandler : BaseQueryHandler<SearchProductsQuery, PagedResponse<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public GetAllProductsQueryHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public override async Task<PagedResponse<ProductDTO>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var searchResult = _mapper.Map<SearchQueryModel<SearchProductFilterModel>>(request);
           return await _productService.SearchAsync(searchResult,cancellationToken);

        }
    }

}
