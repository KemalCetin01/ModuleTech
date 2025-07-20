using FluentValidation;

namespace ModuleTech.Application.Handlers.Product.Commands;

public class UpdateProductCommandValidar : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidar()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.url).NotEmpty().WithMessage("Url is required");
    }
}

