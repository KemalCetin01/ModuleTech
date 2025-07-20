using ModuleTech.Core.Base.IoC;
using ModuleTech.Application.DTOs.Identity;

namespace ModuleTech.Application.Core.Infrastructure.Services;

public interface IAuthTokenService : IScopedService
{
    IdentityUserInfoResponseDto GetUserDetailsFromJwtToken(string token, CancellationToken cancellationToken);

}
