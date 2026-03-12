using ModuleTech.Application.Core.Infrastructure.Services.Category;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.Category.Commands;

public class DeleteCategoryCommand : ICommand
{
    public Guid Id { get; set; }
}

public sealed class DeleteCategoryCommandHandler : BaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryService _categoryService;

    public DeleteCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override async Task Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        await _categoryService.DeleteAsync(command.Id, cancellationToken).ConfigureAwait(false);
    }
}
