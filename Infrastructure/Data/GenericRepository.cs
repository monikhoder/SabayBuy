using System;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public bool Exists(Guid id)
    {
        return context.Set<T>().Any(e => e.Id == id);
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        return context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
    {
       return await ApplySpecification(spec).FirstOrDefaultAsync();
    }


    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.Getquery(context.Set<T>().AsQueryable(), spec);
    }
}
