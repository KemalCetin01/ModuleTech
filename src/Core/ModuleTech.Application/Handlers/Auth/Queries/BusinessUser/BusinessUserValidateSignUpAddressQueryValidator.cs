using FluentValidation;
using ModuleTech.Application.Handlers.Auth.Queries;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser;

public class BusinessUserValidateSignUpAddressQueryValidator : AbstractValidator<BusinessUserValidateSignUpAddressQuery>
{
    public BusinessUserValidateSignUpAddressQueryValidator()
    {
        RuleFor(x => x.CountryId).NotEmpty()
            .GreaterThanOrEqualTo(1); 
       
        RuleFor(x => x.CityId).NotEmpty()
            .GreaterThanOrEqualTo(1); 


        RuleFor(x => x.AddressName).NotEmpty().MaximumLength(256)
            .WithMessage("It cannot be saved without entering Address Name information. And it must be a maximum of 256 characters.");

        RuleFor(x => x.AddressLine1).NotEmpty().MaximumLength(256)
            .WithMessage("It cannot be saved without entering Address Line 1 information. And it must be a maximum of 256 characters.");
        
        RuleFor(x => x.AddressLine2).NotEmpty().MaximumLength(256)
            .WithMessage("It cannot be saved without entering Address Line 2 information. And it must be a maximum of 256 characters.");
        
        RuleFor(x => x.Region).NotEmpty().MaximumLength(64)
            .WithMessage("It cannot be saved without entering Region information. And it must be a maximum of 64 characters.");
        
        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(15)
            .WithMessage("It cannot be saved without entering Zip Code information. And it must be a maximum of 15 characters.");

      
    }
}
