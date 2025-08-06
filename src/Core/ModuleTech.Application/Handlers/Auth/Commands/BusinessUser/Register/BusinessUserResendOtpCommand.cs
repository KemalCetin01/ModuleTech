using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;

namespace ModuleTech.Application.Handlers.Auth.Commands.B2CUser.Register;

public class BusinessUserResendOtpCommand :  ICommand<ResendOtpDTO>
{
}
public sealed class BusinessUserResendOtpCommandHandler : BaseCommandHandler<BusinessUserResendOtpCommand, ResendOtpDTO>
{
    private readonly IAuthBusinessUserService _authenticationService;

    public BusinessUserResendOtpCommandHandler(IAuthBusinessUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override async Task<ResendOtpDTO> Handle(BusinessUserResendOtpCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.BusinessUserResendOtpAsync(cancellationToken);
    }
}

