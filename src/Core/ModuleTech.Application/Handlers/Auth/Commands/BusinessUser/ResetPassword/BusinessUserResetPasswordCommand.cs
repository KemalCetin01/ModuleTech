using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.ResetPassword;

public class BusinessUserResetPasswordCommand : ResetPasswordCommandDTO, ICommand<VerifyOtpDTO>
{
}
public sealed class BusinessUserResetPasswordCommandHandler : BaseCommandHandler<BusinessUserResetPasswordCommand, VerifyOtpDTO>
{
    private readonly IAuthBusinessUserService _authenticationService;

    public BusinessUserResetPasswordCommandHandler(IAuthBusinessUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<VerifyOtpDTO> Handle(BusinessUserResetPasswordCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.ResetPasswordAsync(request, UserTypeEnum.BusinessUser, cancellationToken);
    }
}

