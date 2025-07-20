using ModuleTech.Core.Base.Interface;
using ModuleTech.Domain;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Core.Persistence.Repositories.UserOtp;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetById(Guid Id, CancellationToken cancellationToken);
    Task<bool> EmailExist(string email);
    Task<User?> GetByEmailAsync(string email, UserTypeEnum platform, CancellationToken cancellationToken);
    Task<bool> AnotherUserHasEmailAsync(Guid? userId, UserTypeEnum userType, string email, CancellationToken cancellationToken);
}