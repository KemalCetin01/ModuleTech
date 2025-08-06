using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.IoC;
using ModuleTech.Application.Handlers.Auth.DTOs;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Core.Infrastructure.Services;

public interface IAuthBusinessUserService : IScopedService
{
    Task<AuthenticationDTO> BusinessUserLoginAsync(BusinessUserLoginDTO loginDTO, CancellationToken cancellationToken);
    Task<AuthenticationDTO> BusinessUserRefreshTokenLoginAsync(string refreshToken, CancellationToken cancellationToken);
    Task<SignUpDTO> BusinessUserSignUpAsync(BusinessUserSignupCommandDTO model, CancellationToken cancellationToken);
    Task<bool> BusinessUserVerifyOtpAsync(VerifyOtpDTO model, CancellationToken cancellationToken);
    Task<ResendOtpDTO> BusinessUserResendOtpAsync(CancellationToken cancellationToken);
    Task<VerifyOtpDTO> ResetPasswordAsync(ResetPasswordCommandDTO model, UserTypeEnum platform, CancellationToken cancellationToken);
    Task<ResetVerifyOtpDTO> ResetVerifyOtpAsync(VerifyOtpDTO model, UserTypeEnum platform, CancellationToken cancellationToken);
    Task<bool> ChangePasswordAsync(ChangePasswordCommandDTO model,string realm, CancellationToken cancellationToken);
   

}
