using System;
using Core.Entities;

namespace Core.Interface;

public interface IGenericRepository<T>where T : BaseEntity
{

    //Get data with specification
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);

    //CRUD operations
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);


    bool Exists(Guid id);
    //Save changes
    Task<bool> SaveAllAsync();
}
