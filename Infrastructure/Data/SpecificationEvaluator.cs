using System;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> Getquery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // Apply filtering criteria
        }
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy); // Apply ordering
        }
        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending); // Apply descending ordering
        }
        if (spec.IsDistinct)
        {
            query = query.Distinct(); // Apply distinct if specified
        }

        query = spec.IncludeStrings.Aggregate(query, (current, include) => current.Include(include)); // Apply string includes
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include)); // Apply includes

        return query;
    }

    public static IQueryable<TResult> Getquery<TSpec,TResult>(IQueryable<TEntity> inputQuery, ISpecification<TEntity, TResult> spec)
    {
         var query = inputQuery;
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // Apply filtering criteria
        }
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy); // Apply ordering
        }
        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending); // Apply descending ordering
        }
        var projectedQuery = query as IQueryable<TResult>;
        if(spec.Selector != null)
        {
            projectedQuery = query.Select(spec.Selector); // Apply projection
        }
        return projectedQuery ?? query.Cast<TResult>();
    }
}