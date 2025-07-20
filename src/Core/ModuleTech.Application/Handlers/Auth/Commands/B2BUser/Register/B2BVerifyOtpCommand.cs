using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;

namespace ModuleTech.Application.Handlers.Auth.Commands.B2BUser.Register;

public class B2BVerifyOtpCommand : VerifyOtpDTO, ICommand<DataResponse<bool>>
{
}
public sealed class B2BVerifyOtpCommandHandler : BaseCommandHandler<B2BVerifyOtpCommand, DataResponse<bool>>
{
    private readonly IAuthB2BService _authenticationService;

    public B2BVerifyOtpCommandHandler(IAuthB2BService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<DataResponse<bool>> Handle(B2BVerifyOtpCommand request, CancellationToken cancellationToken)
    {
        var result= await _authenticationService.B2BVerifyOtpAsync(request, cancellationToken);
        return new DataResponse<bool> { Data = result };

    }
}

