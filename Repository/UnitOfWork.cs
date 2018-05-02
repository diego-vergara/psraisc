using Microsoft.EntityFrameworkCore;
using Repository.Core;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }
        public FondoRepository FondoRepository { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
            FondoRepository = new FondoRepository(Context);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
