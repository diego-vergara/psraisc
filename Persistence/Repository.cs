using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext Context;
        private readonly DbSet<T> Entities;

        public Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
            Entities = Context.Set<T>();
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Entities.AddRange(entities);
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
        }

        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public T Get(int id)
        {
            return Entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public IEnumerable<T> GetList(int pageIndex, int pageSize)
        {
            return Entities
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
