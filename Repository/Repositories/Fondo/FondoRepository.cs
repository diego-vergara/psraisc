using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class FondoRepository : Repository<Fondo>, IFondoRepository
    {
        public FondoRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
