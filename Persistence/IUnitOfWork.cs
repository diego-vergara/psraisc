using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; } 
        int Commit();
    }
}
