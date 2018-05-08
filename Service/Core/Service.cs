using Microsoft.EntityFrameworkCore;
using Model.Response;
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
        public readonly DbSet<T> Entity ;

        public Service(DbContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
            Entity = Context.Set<T>();
        }

        public void Add(T entity)
        {
            Entity.Add(entity);
        }

        public void AddAsync(T entity)
        {
            Entity.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            Entity.AddRange(entity);
        }

        public void AddRangeAsync(IEnumerable<T> entities)
        {
            Entity.AddRangeAsync(entities);
            
        }

        public bool Commit()
        {
            try
            {
                return Context.SaveChanges() > 0;
            }       
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                var result = await Context.SaveChangesAsync();
                return (result > 0);
            }
            catch (Exception e)
            {
                return false;
            }
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

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties == null || includeProperties.Length == 0)
            {
                return Entity.ToList();
            }

            return this
                    .IncludeMultiple(includeProperties)
                    .ToList();
        }

        public Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties == null || includeProperties.Length == 0)
            {
                return Entity.ToListAsync();
            }

            return this
                    .IncludeMultiple(includeProperties)
                    .ToListAsync();
        }

        public Task<T> GetAsync(object id)
        {
            return Entity
                    .FindAsync(id);
        }

        public PageListResponse<T> GetList(int pageIndex, int pageSize)
        {
            var totalPages = Entity.Count() / pageSize;
            if (pageIndex <= 0 || pageIndex > totalPages)
            {
                pageIndex = 1;
            }
            

            var pageList = new PageListResponse<T>();
            pageList.PageIndex = pageIndex;
            pageList.PageSize = pageSize;
            pageList.TotalPages = totalPages;
            pageList.Data = Entity
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            pageList.HasNext = pageIndex < pageList.TotalPages;
            //pageList.HasPrev = 
            return pageList;
        }

        public Task<List<T>> GetListAsync(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }

            return Entity
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
        }

        public T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            if(includeProperties == null || includeProperties.Length == 0)
            {
                return Entity
                        .SingleOrDefault(where);
                        
            }
            return this
                    .IncludeMultiple(includeProperties)
                    .SingleOrDefault(where);
        }


        public Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties == null || includeProperties.Length == 0)
            {
                return Entity
                        .SingleOrDefaultAsync(where);

            }
            return this
                    .IncludeMultiple(includeProperties)
                    .SingleOrDefaultAsync(where);
        }

        protected IQueryable<T> IncludeMultiple(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Entity.AsQueryable();
            foreach (var include in includeProperties)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
