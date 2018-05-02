using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FondoService : Service<Fondo>
    {
        public FondoService(DbConext context) 
            : base(context)
        {
        }
    }
}
