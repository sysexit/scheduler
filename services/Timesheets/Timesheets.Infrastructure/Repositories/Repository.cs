using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TimesheetsContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(TimesheetsContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
        }

        public virtual async Task<TEntity> GetByIDAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> GetSingleBySpec(ISpecification<TEntity> spec)
        {
            var result = await List(spec);
            return result.FirstOrDefault();
        }

        public async Task<List<TEntity>> List(ISpecification<TEntity> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(DbSet.AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
