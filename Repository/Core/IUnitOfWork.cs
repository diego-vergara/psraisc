using System;

namespace Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {

        int Commit();
    }
}
