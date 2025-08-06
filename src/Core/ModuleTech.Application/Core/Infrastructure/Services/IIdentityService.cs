using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.DTOs.Identity.Response;

namespace ModuleTech.Application.Core.Infrastructure.Services;

public interface IIdentityBusinessUserService : IIdentityBaseService
{
    Task<AuthenticationDTO> LoginAsync(BusinessUserLoginDTO request, CancellationToken cancellationToken);
    Task<AuthenticationDTO> RefreshTokenLoginAsync(string refreshToken, CancellationToken cancellationToken);

}