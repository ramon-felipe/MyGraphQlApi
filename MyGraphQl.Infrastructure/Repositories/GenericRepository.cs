﻿using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using MyGraphQl.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace MyGraphQl.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>[]? conditionExpressions = null,
        QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking,
        params Expression<Func<T, object>>[] includeExpressions);

    Task<T> GetByIdAsync(int id, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[]? includeExpressions);

    Task<IEnumerable<T>> GetByIdAsync(IEnumerable<int> ids, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[] includeExpressions);
}

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(IMyGraphQlContext context)
    {
        this._dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>[]? conditionExpressions = null,
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

    public async Task<T> GetByIdAsync(int id, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[]? includeExpressions )
    {
        var ids = new List<int> { id };

        var result = (await this.GetByIdAsync(ids, trackingBehavior, includeExpressions))
            .SingleOrDefault();

        return result;
    }

    public async Task<IEnumerable<T>> GetByIdAsync(IEnumerable<int> ids, QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking, params Expression<Func<T, object>>[]? includeExpressions)
    {
        return await this
            ._dbSet
            .UseTrackingBehavior(trackingBehavior)
            .AddIncludes(includeExpressions)
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
    }

}
