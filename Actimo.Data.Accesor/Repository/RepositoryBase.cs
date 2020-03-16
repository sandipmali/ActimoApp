using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Actimo.Data.Accesor.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T>, IDisposable where T : class
    {
        internal DWContext RepositoryContext;
        internal DbSet<T> DWDbSet;

        protected RepositoryBase(DWContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            DWDbSet = RepositoryContext.Set<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public void Create(T entity)
        {
            DWDbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            if (RepositoryContext.Entry(entity).State == EntityState.Detached) DWDbSet.Attach(entity);
            DWDbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            DWDbSet.Attach(entity);
            RepositoryContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await RepositoryContext.SaveChangesAsync();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = DWDbSet;
            if (filter != null) query = query.Where(filter);
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);
            if (orderBy != null) return orderBy(query).ToList();
            return query.ToList();
        }

        public virtual T GetByIdAsync(object id)
        {
            return DWDbSet.Find(id); //.AsNoTracking()
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DWDbSet.Find(id);
            Delete(entityToDelete);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && RepositoryContext != null)
            {
                RepositoryContext.Dispose();
                RepositoryContext = null;
            }
        }        
    }
}
