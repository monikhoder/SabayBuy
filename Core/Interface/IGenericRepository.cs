using System;
using Core.Entities;

namespace Core.Interface;

public interface IGenericRepository<T>where T : BaseEntity
{
    // get by id
    Task<T?> GetByIdAsync(Guid id);

    //Get data with specification
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);

    // Get data with specification and projection
    Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> spec);
    Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec);

    //CRUD operations
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);


    bool Exists(Guid id);
    //Save changes
    Task<bool> SaveAllAsync();
}
