using FluentValidation;

namespace ModuleTech.Application.Handlers.Category.Commands;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id zorunludur");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad zorunludur");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama zorunludur");
    }
}
