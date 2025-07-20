using ModuleTech.Application.Core.Infrastructure.Services.Product;
using ModuleTech.Application.DTOs.Product.Response;
using ModuleTech.Application.Handlers.Product.DTOs;
using ModuleTech.Core.Base.Handlers;
using AutoMapper;

namespace ModuleTech.Application.Handlers.Product.Queries;
public class GetProductDetailsQuery : IQuery<ProductDTO>
{
    public Guid Id{ get; set; }
}
public sealed class GetProductDetailsQueryHandler : BaseQueryHandler<GetProductDetailsQuery, ProductDTO>
{
        private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public GetProductDetailsQueryHandler(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public override async Task<ProductDTO> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
      
        var result = await _productService.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<ProductDTO>(result) ;
    }
}
