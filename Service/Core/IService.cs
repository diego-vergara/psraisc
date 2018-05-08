using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Core
{
    public interface IService<T> where T : class
    {
        T Get(object id);
        T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        PageListResponse<T> GetList(int pageIndex, int pageSize);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        void Edit(T entity);

        bool Commit();
    }
}
