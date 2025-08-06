using FluentValidation;
using ModuleTech.Application.Handlers.Auth.Queries;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser;

public class BusinessUserInformationValidationQueryValidator : AbstractValidator<BusinessUserValidateSignUpInfoQuery>
{
    public BusinessUserInformationValidationQueryValidator()
    {
        RuleFor(x => x.CompanyName).NotEmpty().MaximumLength(256)
            .WithMessage("It cannot be saved without entering company information. And it must be a maximum of 256 characters.");

        RuleFor(x => x.SectorId).NotEmpty()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.NumberOfEmployeeId).NotEmpty()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.ActivityAreaId).NotEmpty()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(256)
            .WithMessage("It cannot be saved without entering First Name information. And it must be a maximum of 256 characters.");

        RuleFor(x => x.LastName).NotEmpty().MaximumLength(256)
            .WithMessage("It cannot be saved without entering Last Name information. And it must be a maximum of 256 characters.");

        RuleFor(x => x.Suffix).NotEmpty().MaximumLength(10)
            .WithMessage("It cannot be saved without entering Suffix information. And it must be a maximum of 10 characters.");

        RuleFor(x => x.PositionId).NotEmpty()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.OccupationId).NotEmpty()
            .GreaterThanOrEqualTo(1);
    }
}
