using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using ModuleTech.Core.Base.Attributes;
using ModuleTech.Core.BaseEntities;
using ModuleTech.Core.Base.Concrete;
using ModuleTech.Core.Base.Interface;
using ModuleTech.Core.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace ModuleTech.Core.Data.Data.Concrete;

public class Repository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity where TContext : BaseDbContext
{
    private readonly DbSet<TEntity> _entitiySet;

    public Repository(TContext dbContext) => _entitiySet = dbContext.Set<TEntity>();

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) =>
        await _entitiySet.AddAsync(entity, cancellationToken);

    public void Add(TEntity entity) => _entitiySet.Add(entity);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
        await _entitiySet.AddRangeAsync(entities, cancellationToken);
     
    public void Update(TEntity entity) => _entitiySet.Update(entity);

    public void Remove(TEntity entity) => _entitiySet.Remove(entity);

    public async Task<TEntity?> GetById(object id, CancellationToken cancellationToken) =>
        await _entitiySet.FindAsync(new[] {id}, cancellationToken);

    protected IQueryable<TEntity> Queryable() => _entitiySet;

    #region Search

    protected async Task<SearchListModel<TEntity>> SearchAsync<TFilter>(IQueryable<TEntity> query,
        SearchQueryModel<TFilter> searchQuery,
        CancellationToken cancellationToken = default) where TFilter : IFilterModel
    {
        query = GlobalSearchQuery(query, searchQuery.GlobalSearch);
        var rowCount = await query.CountAsync(cancellationToken);
        query = SearchOrderQuery(query, searchQuery.Sort);
        query = PaginationQuery(query, searchQuery.Pagination);
        return await ToListAsync(query, searchQuery, rowCount, cancellationToken);
    }

    protected async Task<SearchListModel<TEntity>> ToListAsync<TFilter>(IQueryable<TEntity> query,
        SearchQueryModel<TFilter> searchQuery, int rowCount,
        CancellationToken cancellationToken = default) where TFilter : IFilterModel
    {
        var entities = await query.ToListAsync(cancellationToken);
        return new SearchListModel<TEntity>(entities, searchQuery.Pagination?.CurrentPage,
            searchQuery.Pagination?.PageSize, rowCount);
    }

    protected async Task<SearchListModel<TEntity>> ToPaginationListAsync<TFilter>(IQueryable<TEntity> query,
        SearchQueryModel<TFilter> searchQuery,
        CancellationToken cancellationToken = default) where TFilter : IFilterModel
    {
        var rowCount = await query.CountAsync(cancellationToken);
        query = PaginationQuery(query, searchQuery.Pagination);
        return await ToListAsync(query, searchQuery, rowCount, cancellationToken);
    }

    #endregion

    #region Search (Queryable)

    protected IQueryable<TEntity> Search<TFilter>(SearchQueryModel<TFilter> searchQuery) where TFilter : IFilterModel
    {
        var query = SearchWithoutPagination(searchQuery);
        query = PaginationQuery(query, searchQuery.Pagination);
        return query;
    }

    protected IQueryable<TEntity> SearchWithoutPagination<TFilter>(SearchQueryModel<TFilter> searchQuery)
        where TFilter : IFilterModel
    {
        var query = Queryable();
        query = GlobalSearchQuery(query, searchQuery.GlobalSearch);
        query = SearchOrderQuery(query, searchQuery.Sort);
        return query;
    }

    #endregion

    #region Filter Helpers

    protected virtual IQueryable<TEntity> GlobalSearchQuery(IQueryable<TEntity> query, string? globalSearchText)
    {
        var entityType = typeof(TEntity);
        if (!string.IsNullOrWhiteSpace(globalSearchText))
        {
            var props = entityType.GetProperties();
            var properties = new List<PropertyInfo>();
            foreach (var prop in props)
            {
                var p = entityType.GetProperty(prop.Name);
                var a = p?.CustomAttributes != null ? p.GetCustomAttribute(typeof(QuerySearchAttribute)) : null;
                if (a != null && p != null) properties.Add(p);
            }

            if (properties.Any()) query = QuerySearchLikeAny(query, globalSearchText, properties);
        }

        return query;
    }

    protected IQueryable<TEntity> PaginationQuery(IQueryable<TEntity> query, PaginationModel? pagination)
    {
        if (pagination != null && pagination.CurrentPage > 0)
            query = query.Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                .Take(pagination.PageSize);
        return query;
    }

    protected virtual IQueryable<TEntity> SearchOrderQuery(IQueryable<TEntity> query, SortModel? sortModel)
    {
        if (sortModel != null)
            query = sortModel.Direction.ToUpper() == "DESC"
                ? query.OrderByDescending(x =>
                    EF.Property<object>(x, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sortModel.Field)))
                : query.OrderBy(x =>
                    EF.Property<object>(x, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sortModel.Field)));
        return query;
    }

    #endregion

    #region Private Methods

    private IQueryable<TEntity> QuerySearchLikeAny(IQueryable<TEntity> query, string text,
        List<PropertyInfo> properties)
    {
        var parameter = Expression.Parameter(typeof(TEntity));

        var body = properties.Select(property => Expression.Call(
            Expression.Call(
                Expression.PropertyOrField(parameter, property.Name),
                "ToLower", null),
            "Contains", null,
            Expression.Constant(text.ToLower()))).Aggregate<MethodCallExpression, Expression>(null,
            (current, call) => current != null ? Expression.OrElse(current, call) : call);

        return query.Where(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
    }

    #endregion
}