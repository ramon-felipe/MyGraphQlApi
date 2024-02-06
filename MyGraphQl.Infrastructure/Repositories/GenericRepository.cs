using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace MyGraphQl.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>[] conditionExpressions,
        QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking,
        params Expression<Func<T, object>>[] includeExpressions);

    Task<Maybe<T>> GetByIdAsync(int id, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[] includeExpressions);

    Task<IEnumerable<T>> GetByIdAsync(IEnumerable<int> ids, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[] includeExpressions);
}

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly IMyGraphQlContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(IMyGraphQlContext context)
    {
        this._context = context;
        this._dbSet = this._context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>[] conditionExpressions,
        QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking,
        params Expression<Func<T, object>>[] includeExpressions)
    {
        return await this
            ._dbSet
            .UseTrackingBehavior(trackingBehavior)
            .AddWhereClauses(conditionExpressions)
            .AddIncludes(includeExpressions)
            .ToListAsync();
    }

    public async Task<Maybe<T>> GetByIdAsync(int id, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[] includeExpressions)
    {
        var ids = new List<int> { id };

        var result = (await this.GetByIdAsync(ids, trackingBehavior, includeExpressions))
            .SingleOrDefault();

        return result == null ? Maybe.None : Maybe.From(result);
    }

    public async Task<IEnumerable<T>> GetByIdAsync(IEnumerable<int> ids, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[] includeExpressions)
    {
        return await this
            ._dbSet
            .UseTrackingBehavior(trackingBehavior)
            .AddIncludes(includeExpressions)
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
    }

}
