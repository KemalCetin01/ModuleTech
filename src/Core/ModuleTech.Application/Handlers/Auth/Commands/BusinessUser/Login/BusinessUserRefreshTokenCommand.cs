using FluentValidation;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Login;

public class BusinessUserRefreshTokenCommand : ICommand<AuthenticationDTO>
{
    public string RefreshToken { get; set; }

}
public sealed class BusinessUserRefreshTokenCommandHandler : BaseCommandHandler<BusinessUserRefreshTokenCommand, AuthenticationDTO>
{
    private readonly IAuthBusinessUserService _authenticationService;

    public BusinessUserRefreshTokenCommandHandler(IAuthBusinessUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override async Task<AuthenticationDTO> Handle(BusinessUserRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.BusinessUserRefreshTokenLoginAsync(request.RefreshToken, cancellationToken);
    }
}

public class BusinessUserRefreshTokenLoginCommandValidator : AbstractValidator<BusinessUserRefreshTokenCommand>
{
    public BusinessUserRefreshTokenLoginCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}
