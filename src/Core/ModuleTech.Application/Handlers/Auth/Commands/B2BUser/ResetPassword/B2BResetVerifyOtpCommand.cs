using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.Auth.Commands.B2BUser.Register;

public class B2BResetVerifyOtpCommand : VerifyOtpDTO, ICommand<ResetVerifyOtpDTO>
{
}
public sealed class B2BResetVerifyOtpCommandHandler : BaseCommandHandler<B2BResetVerifyOtpCommand, ResetVerifyOtpDTO>
{
    private readonly IAuthB2BService _authenticationService;

    public B2BResetVerifyOtpCommandHandler(IAuthB2BService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<ResetVerifyOtpDTO> Handle(B2BResetVerifyOtpCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.ResetVerifyOtpAsync(request, UserTypeEnum.B2B, cancellationToken);
    }
}

