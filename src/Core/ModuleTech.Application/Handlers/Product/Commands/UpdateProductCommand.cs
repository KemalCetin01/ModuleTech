using ModuleTech.Application.Core.Infrastructure.Services.Product;
using ModuleTech.Application.Handlers.Product.DTOs;
using ModuleTech.Core.Base.Handlers;
using FluentValidation;

namespace ModuleTech.Application.Handlers.Product.Commands;
public class UpdateProductCommand:ICommand<ProductDTO>
{
    public Guid id{ get; set; }
    public string name { get; set; }
    public string url { get; set; }
}
public sealed class UpdateProductCommandHandler : BaseCommandHandler<UpdateProductCommand, ProductDTO>
{
    private readonly IProductService _productService;
    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public override async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
       
        return await _productService.UpdateAsync(request, cancellationToken);
    }
}
