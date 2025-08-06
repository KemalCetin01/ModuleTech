using ModuleTech.Domain.Enums;
using FluentValidation;
using static ModuleTech.Application.Constants.Constants;

namespace ModuleTech.Application.Handlers.User.Commands.BusinessUser;

public class UpdateBusinessUserCommandValidator : AbstractValidator<UpdateBusinessUserCommand>
{
    public UpdateBusinessUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(256)
              .WithMessage("It cannot be saved without entering First Name information. And it must be a maximum of 256 characters.");
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(256)
            .WithMessage("It cannot be saved without entering Last Name information. And it must be a maximum of 256 characters.");

        RuleFor(x => x.CountryId).NotEmpty()
            .GreaterThanOrEqualTo(1);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneCountryCode).NotEmpty().MaximumLength(8)
            .WithMessage("it must be a maximum of 15 characters."); ;
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(15)
            .WithMessage("it must be a maximum of 15 characters.");
        RuleFor(x => x.SiteStatus).NotEmpty();
    }

}
