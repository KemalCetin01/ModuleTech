using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Persistence.Context;
using ModuleTech.Core.Data.Data.Concrete;

namespace ModuleTech.Persistence.UoW;

public class ModuleTechUnitOfWork : UnitOfWork<AppDbContext>, IModuleTechUnitOfWork
{
    public ModuleTechUnitOfWork(AppDbContext dbContext) : base(dbContext)
    {
    }
}