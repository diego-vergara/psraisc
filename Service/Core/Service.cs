using Microsoft.EntityFrameworkCore;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service
{
    public class Service<T> : IService<T>, IServiceAsync<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> Entity;

        public Service(DbContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
            Entity = Context.Set<T>();
        }

        public void Add(T entity)
        {
            Entity.Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            Entity.AddRange(entity);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public Task<int> CommitAysnc()
        {
            return Context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            Entity.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            Entity.RemoveRange(entity);
        }

        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Entity.Where(predicate);
        }

        public T Get(object id)
        {
            return Entity.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entity.ToList();
        }

        public Task<List<T>> GetAllAsync()
        {
            return Entity.ToListAsync();
        }

        public Task<T> GetAsync(object id)
        {
            return Entity.FindAsync(id);
        }

        public IEnumerable<T> GetList(int pageIndex, int pageSize)
        {
            return Entity
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
