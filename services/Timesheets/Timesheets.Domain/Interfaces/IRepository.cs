using System;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIDAsync(Guid id);
        Task<TEntity> GetSingleBySpec(ISpecification<TEntity> spec);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        void Remove(TEntity obj);
        int SaveChanges();
        Task SaveChangesAsync();
    }
}
