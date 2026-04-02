using Core.Entities;
using Core.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork(StoreContext storeContext) : IUnitOfWork
    {
        private readonly ConcurrentDictionary<string, object> repositories = new();
        public async Task<bool> Complete()
        {
            return await storeContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            storeContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity).Name;
            return (IGenericRepository<TEntity>)repositories.GetOrAdd(type, t =>
            {
                var repositoryType = typeof(GenericRepository<>).MakeGenericType(typeof(TEntity));
                return Activator.CreateInstance(repositoryType, storeContext)
                ?? throw new InvalidOperationException($"Can not create repo instance for {t}");
            });
        }
    }
}
