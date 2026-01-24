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
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include)); // Apply includes

        return query;
    }

}
