using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public interface IServiceAsync<T> where T : class
    {
        Task< T > GetAsync(object id);
        Task< List<T> > GetAllAsync();
        Task<List<T>> GetListAsync(int pageIndex, int pageSize);
        //IEnumerable<T> FindAsync(Expression<Func<T, bool>> predicate);
        void AddAsync(T entity);
        void AddRangeAsync(IEnumerable<T> entities);
        //void DeleteAsync(T entity);
        //void DeleteRangeAsync(IEnumerable<T> entities);
        //void EditAsync(T entity);
        Task<int> CommitAsync();
    }
}
