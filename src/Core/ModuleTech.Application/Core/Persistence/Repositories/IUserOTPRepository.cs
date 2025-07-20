using ModuleTech.Core.Base.Interface;
using ModuleTech.Domain;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Core.Persistence.Repositories;

public interface IUserOTPRepository : IRepository<UserOTP>
{
    Task<UserOTP> GetVerifyByIdAsync(Guid transactionId, UserTypeEnum userType, OtpTypeEnum otpType, CancellationToken cancellationToken);
    Task<bool> IsVerifiedAsync(Guid userId, UserTypeEnum userType, OtpTypeEnum otpType, CancellationToken cancellationToken);
}
