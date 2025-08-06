using Microsoft.Extensions.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;
using ModuleTech.Application.Helpers;
using ModuleTech.Application.Helpers.Options;

namespace ModuleTech.Application.Handlers.Auth.Commands.BusinessUser.Register;

public class BusinessUserChangePasswordCommand : ChangePasswordCommandDTO, ICommand<DataResponse<bool>>
{
}
public sealed class BusinessUserChangePasswordCommandHandler : BaseCommandHandler<BusinessUserChangePasswordCommand, DataResponse<bool>>
{
    private readonly IAuthBusinessUserService _authenticationService;
    private readonly KeycloakOptions _keycloakOptions;

    public BusinessUserChangePasswordCommandHandler(IAuthBusinessUserService authenticationService,
                                 IOptions<KeycloakOptions> options)
    {
        _authenticationService = authenticationService;
        _keycloakOptions = options.Value;
    }


    public override async Task<DataResponse<bool>> Handle(BusinessUserChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var result= await _authenticationService.ChangePasswordAsync(request, _keycloakOptions.moduleTech_realm, cancellationToken);
        return new DataResponse<bool> {Data= result };
    }
}

