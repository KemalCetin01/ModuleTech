using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;

namespace ModuleTech.Application.Handlers.Auth.Commands.B2BUser.Register;

public class B2BSignUpCommand : B2BSignupCommandDTO, ICommand<SignUpDTO>
{
}
public sealed class B2BSignUpCommandHandler : BaseCommandHandler<B2BSignUpCommand, SignUpDTO>
{
    private readonly IAuthB2BService _authenticationService;
    public B2BSignUpCommandHandler(IAuthB2BService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<SignUpDTO> Handle(B2BSignUpCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.B2BSignUpAsync(request, cancellationToken);
    }
}

