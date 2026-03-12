using ModuleTech.Application.Core.Infrastructure.Services.Category;
using ModuleTech.Application.Handlers.Category.DTOs;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.Category.Commands;

public class UpdateCategoryCommand : ICommand<CategoryDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public sealed class UpdateCategoryCommandHandler : BaseCommandHandler<UpdateCategoryCommand, CategoryDTO>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override async Task<CategoryDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.UpdateAsync(request, cancellationToken);
    }
}
