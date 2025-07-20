using Microsoft.Extensions.Options;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;
using ModuleTech.Application.Helpers;
using ModuleTech.Application.Helpers.Options;

namespace ModuleTech.Application.Handlers.Auth.Commands.B2BUser.Register;

public class B2BChangePasswordCommand : ChangePasswordCommandDTO, ICommand<DataResponse<bool>>
{
}
public sealed class B2BChangePasswordCommandHandler : BaseCommandHandler<B2BChangePasswordCommand, DataResponse<bool>>
{
    private readonly IAuthB2BService _authenticationService;
    private readonly KeycloakOptions _keycloakOptions;

    public B2BChangePasswordCommandHandler(IAuthB2BService authenticationService,
                                 IOptions<KeycloakOptions> options)
    {
        _authenticationService = authenticationService;
        _keycloakOptions = options.Value;
    }


    public override async Task<DataResponse<bool>> Handle(B2BChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var result= await _authenticationService.ChangePasswordAsync(request, _keycloakOptions.moduleTech_realm, cancellationToken);
        return new DataResponse<bool> {Data= result };
    }
}

