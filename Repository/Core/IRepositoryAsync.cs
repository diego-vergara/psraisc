using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<List<T>> GetAllAsync();
    }
}
