using ModuleTech.Application.Core.Persistence.Repositories.UserOtp;
using ModuleTech.Core.Data.Data.Concrete;
using ModuleTech.Domain;
using ModuleTech.Domain.Enums;
using ModuleTech.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ModuleTech.Identity.Persistence.Repositories;

public class UserRepository : Repository<User, AppDbContext>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> EmailExist(string email)
    {
        return Queryable().Where(x => x.Email == email).Count() > 0 ? true : false;
    }

    public async Task<User?> GetByEmailAsync(string email, UserTypeEnum platform, CancellationToken cancellationToken)
    {
        return await Queryable().Where(x => x.Email == email && !x.IsDeleted).FirstOrDefaultAsync();

    }

    public async Task<User> GetById(Guid Id, CancellationToken cancellationToken)
    {
        return await Queryable()
            .Where(x => x.Id == Id && x.IsDeleted == false).FirstOrDefaultAsync(cancellationToken);
    }

    //deleted kayıtlar default olarak gönmüyor
    public async Task<bool> AnotherUserHasEmailAsync(Guid? userId, UserTypeEnum userType, string email, CancellationToken cancellationToken)
    {
        var query = Queryable();
        if (userId != null) query = query.Where(x => x.Id != userId && !x.IsDeleted);
        return await query.AnyAsync(x =>x.Email == email && !x.IsDeleted, cancellationToken);
    }

}