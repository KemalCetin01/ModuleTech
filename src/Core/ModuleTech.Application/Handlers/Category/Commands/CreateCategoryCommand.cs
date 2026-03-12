using ModuleTech.Application.Core.Infrastructure.Services.Category;
using ModuleTech.Application.Handlers.Category.DTOs;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.Category.Commands;

public class CreateCategoryCommand : ICommand<CategoryDTO>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public sealed class CreateCategoryCommandHandler : BaseCommandHandler<CreateCategoryCommand, CategoryDTO>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.AddAsync(request, cancellationToken);
    }
}
