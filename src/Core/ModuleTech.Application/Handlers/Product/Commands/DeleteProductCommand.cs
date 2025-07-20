using ModuleTech.Application.Core.Infrastructure.Services.Product;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.Product.Commands;

public class DeleteProductCommand:ICommand
{
    public Guid id { get; set; }
}
public sealed class DeleteProductCommandHandler : BaseCommandHandler<DeleteProductCommand>
{
    private readonly IProductService _productService;
    public DeleteProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task Handle(DeleteProductCommand command,CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(command.id, cancellationToken).ConfigureAwait(false);
    }
}