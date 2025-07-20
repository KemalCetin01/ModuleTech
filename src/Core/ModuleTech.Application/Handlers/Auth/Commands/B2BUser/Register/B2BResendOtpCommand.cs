using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;

namespace ModuleTech.Application.Handlers.Auth.Commands.B2CUser.Register;

public class B2BResendOtpCommand :  ICommand<ResendOtpDTO>
{
}
public sealed class B2BResendOtpCommandHandler : BaseCommandHandler<B2BResendOtpCommand, ResendOtpDTO>
{
    private readonly IAuthB2BService _authenticationService;

    public B2BResendOtpCommandHandler(IAuthB2BService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override async Task<ResendOtpDTO> Handle(B2BResendOtpCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.B2BResendOtpAsync(cancellationToken);
    }
}

