using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class AdministradoraService : Service<Administradora>
    {
        public AdministradoraService(CloudContext context) 
            : base(context)
        {

        }

        public Task<List<Administradora>> GetWithFondos()
        {
            return
                Entity
                    .Include(e => e.Fondo)
                    .ToListAsync();
        }

    }
}
