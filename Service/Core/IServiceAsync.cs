using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public interface IServiceAsync<T> where T : class
    {
        Task< T > GetAsync(object id);
        Task< List<T> > GetAllAsync();
        Task<int> CommitAysnc();
    }
}
