using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Core.Data.Data.Concrete;
using ModuleTech.Domain.Enums;
using ModuleTech.Persistence.Context;

namespace ModuleTech.Persistence.Repositories;

public class UserResetPasswordRepository : Repository<UserResetPassword, AppDbContext>, IUserResetPasswordRepository
{
    public UserResetPasswordRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserResetPassword> GetVerifyByIdAsync(Guid transactionId, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        return await Queryable().Include(x => x.UserOTP).Where(x => !x.IsUsed && x.Id == transactionId && x.UserOTP.OtpType == OtpTypeEnum.ResetPassword && x.ExpireDate >now).OrderByDescending(x => x.Id).FirstOrDefaultAsync(cancellationToken);
    }
}
