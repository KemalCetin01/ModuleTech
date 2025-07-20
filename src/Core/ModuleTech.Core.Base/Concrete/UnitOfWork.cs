using ModuleTech.Core.Base.Concrete;
using ModuleTech.Core.Base.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ModuleTech.Core.Data.Data.Concrete;

public abstract class UnitOfWork<TContext> : IUnitOfWork where TContext : BaseDbContext
{
    private readonly TContext _dbContext;
    private IDbContextTransaction _currentTransaction;
    protected UnitOfWork(TContext dbContext) => _dbContext = dbContext;

    [Obsolete("Use async implementation instead of this", true)]
    public int Commit() => _dbContext.SaveChanges();

    public async Task<int> CommitAsync(CancellationToken cancellationToken) =>
        await _dbContext.SaveChangesAsync(cancellationToken);

    public void Rollback() => _dbContext.Dispose();

    #region Transaction

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null) return;
        _currentTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction == null)
            throw new InvalidOperationException("No active transaction.");
        
        try
        {
            await _currentTransaction.CommitAsync(cancellationToken);
        }
        catch(Exception)
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            await _currentTransaction.DisposeAsync();
            await _dbContext.DisposeAsync();
        }
    }
    public async Task TransactionDisposeAsync()
    {
        await _currentTransaction.DisposeAsync();
        await _dbContext.DisposeAsync();
    }
    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_currentTransaction != null)
                await _currentTransaction.RollbackAsync(cancellationToken);
        }
        finally
        {
            await _currentTransaction.DisposeAsync();
            await _dbContext.DisposeAsync();
        }
    }
    #endregion
}