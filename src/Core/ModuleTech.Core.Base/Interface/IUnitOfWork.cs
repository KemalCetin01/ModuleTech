using Microsoft.EntityFrameworkCore.Storage;

namespace ModuleTech.Core.Base.Interface;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
    int Commit();
    void Rollback();
    #region Transaction
    IDbContextTransaction GetCurrentTransaction();
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    Task TransactionDisposeAsync();
    #endregion
}