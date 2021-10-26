using System;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIDAsync(int id);
        Task<TEntity> GetSingleBySpec(ISpecification<TEntity> spec);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        int SaveChanges();
        Task SaveChangesAsync();
    }
}
