using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Register;

public class BusinessUserResetVerifyOtpCommand : VerifyOtpDTO, ICommand<ResetVerifyOtpDTO>
{
}
public sealed class BusinessUserResetVerifyOtpCommandHandler : BaseCommandHandler<BusinessUserResetVerifyOtpCommand, ResetVerifyOtpDTO>
{
    private readonly IAuthBusinessUserService _authenticationService;

    public BusinessUserResetVerifyOtpCommandHandler(IAuthBusinessUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<ResetVerifyOtpDTO> Handle(BusinessUserResetVerifyOtpCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.ResetVerifyOtpAsync(request, UserTypeEnum.BusinessUser, cancellationToken);
    }
}

