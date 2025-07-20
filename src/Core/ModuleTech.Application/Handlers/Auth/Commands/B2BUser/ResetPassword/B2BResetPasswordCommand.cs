using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.Auth.Commands.B2BUser.ResetPassword;

public class B2BResetPasswordCommand : ResetPasswordCommandDTO, ICommand<VerifyOtpDTO>
{
}
public sealed class B2BResetPasswordCommandHandler : BaseCommandHandler<B2BResetPasswordCommand, VerifyOtpDTO>
{
    private readonly IAuthB2BService _authenticationService;

    public B2BResetPasswordCommandHandler(IAuthB2BService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<VerifyOtpDTO> Handle(B2BResetPasswordCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.ResetPasswordAsync(request, UserTypeEnum.B2B, cancellationToken);
    }
}

