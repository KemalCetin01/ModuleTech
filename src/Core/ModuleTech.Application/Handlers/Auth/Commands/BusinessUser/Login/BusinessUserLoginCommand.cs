using ModuleTech.Core.Base.Handlers;
using FluentValidation;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Login;

public class BusinessUserLoginCommand : BusinessUserLoginDTO, ICommand<AuthenticationDTO>
{
}
public sealed class BusinessUserLoginCommandHandler : BaseCommandHandler<BusinessUserLoginCommand, AuthenticationDTO>
{
    private readonly IAuthBusinessUserService _authenticationService;

    public BusinessUserLoginCommandHandler(IAuthBusinessUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<AuthenticationDTO> Handle(BusinessUserLoginCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.BusinessUserLoginAsync(request, cancellationToken);
    }
}

public class BusinessUserLoginCommandValidator : AbstractValidator<BusinessUserLoginCommand>
{
    public BusinessUserLoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}

