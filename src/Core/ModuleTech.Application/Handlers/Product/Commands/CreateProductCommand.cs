using ModuleTech.Application.Core.Infrastructure.Services.Product;
using ModuleTech.Application.Handlers.Product.DTOs;
using ModuleTech.Core.Base.Handlers;
using System.Windows.Input;

namespace ModuleTech.Application.Handlers.Product.Commands;
public class CreateProductCommand:ICommand<ProductDTO>
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public sealed class CreateProductCommandHandler : BaseCommandHandler<CreateProductCommand, ProductDTO>
{
    private readonly IProductService _productService;

    public CreateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productService.AddAsync(request, cancellationToken);

    }
}