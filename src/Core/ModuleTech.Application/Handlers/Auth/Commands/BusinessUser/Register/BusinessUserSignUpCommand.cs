using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Register;

public class BusinessUserSignUpCommand : BusinessUserSignupCommandDTO, ICommand<SignUpDTO>
{
}
public sealed class BusinessUserSignUpCommandHandler : BaseCommandHandler<BusinessUserSignUpCommand, SignUpDTO>
{
    private readonly IAuthBusinessUserService _authenticationService;
    public BusinessUserSignUpCommandHandler(IAuthBusinessUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<SignUpDTO> Handle(BusinessUserSignUpCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.BusinessUserSignUpAsync(request, cancellationToken);
    }
}

