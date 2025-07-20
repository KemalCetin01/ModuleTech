using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.DTOs.Identity;

namespace ModuleTech.Application.Handlers.Auth.Queries;

public class GetUserInfoQuery : IQuery<IdentityUserInfoResponseDto>
{
    public string Token { get; set; }
}
public sealed class GetUserInfoQueryHandler : BaseQueryHandler<GetUserInfoQuery, IdentityUserInfoResponseDto>
{
    private readonly IAuthTokenService _authTokenService;
    public GetUserInfoQueryHandler(IAuthTokenService authTokenService)
    {
        _authTokenService = authTokenService;
    }

    public override async Task<IdentityUserInfoResponseDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        return _authTokenService.GetUserDetailsFromJwtToken(request.Token, cancellationToken);
    }
}