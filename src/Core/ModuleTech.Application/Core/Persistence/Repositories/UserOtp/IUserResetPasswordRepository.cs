using ModuleTech.Core.Base.Interface;
using ModuleTech.Domain;

namespace ModuleTech.Application.Core.Persistence.Repositories;

public interface IUserResetPasswordRepository : IRepository<UserResetPassword>
{
    Task<UserResetPassword> GetVerifyByIdAsync(Guid transactionId, CancellationToken cancellationToken);
}
