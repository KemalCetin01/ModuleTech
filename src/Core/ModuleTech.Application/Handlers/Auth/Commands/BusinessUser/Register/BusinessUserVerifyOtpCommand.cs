using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Register;

public class BusinessUserVerifyOtpCommand : VerifyOtpDTO, ICommand<DataResponse<bool>>
{
}
public sealed class BusinessUserVerifyOtpCommandHandler : BaseCommandHandler<BusinessUserVerifyOtpCommand, DataResponse<bool>>
{
    private readonly IAuthBusinessUserService _authenticationService;

    public BusinessUserVerifyOtpCommandHandler(IAuthBusinessUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    public override async Task<DataResponse<bool>> Handle(BusinessUserVerifyOtpCommand request, CancellationToken cancellationToken)
    {
        var result= await _authenticationService.BusinessUserVerifyOtpAsync(request, cancellationToken);
        return new DataResponse<bool> { Data = result };

    }
}

