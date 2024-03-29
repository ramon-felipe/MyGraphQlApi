﻿using Microsoft.EntityFrameworkCore;
using MyGraphQl.Domain;
using System.Linq.Expressions;

namespace MyGraphQl.Infrastructure.Extensions;
internal static class IQueryableExtensions
{
    public static IQueryable<TEntity> UseTrackingBehavior<TEntity>(this IQueryable<TEntity> queryable, QueryTrackingBehavior trackingBehavior)
        where TEntity : BaseEntity
    {
        return trackingBehavior switch
        {
            QueryTrackingBehavior.TrackAll => queryable.AsTracking(),
            QueryTrackingBehavior.NoTracking => queryable.AsNoTracking(),
            QueryTrackingBehavior.NoTrackingWithIdentityResolution => queryable.AsNoTrackingWithIdentityResolution(),
            _ => throw new NotImplementedException()
        };
    }

    public static IQueryable<TEntity> AddIncludes<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, object>>[]? expressions)
        where TEntity : BaseEntity
    {
        if (expressions == null)
            return queryable;

        foreach (var exp in expressions)
        {
            queryable = queryable.Include(exp);
        }

        return queryable;
    }

    public static IQueryable<T> AddWhereClauses<T>(this IQueryable<T> queryable, Expression<Func<T, bool>>[]? expressions)
        where T : BaseEntity
    {
        if (expressions == null)
            return queryable;

        foreach (var exp in expressions)
        {
            queryable = queryable.Where(exp);
        }

        return queryable;
    }
}
